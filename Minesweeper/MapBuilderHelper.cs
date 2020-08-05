using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Mines
{

    public static class MapBuilderHelper
    {
        public static IGameControl CreateControl(this MinesOptions options)
            => new GameControl(options);

        public static IDictionary<Point, IBlock> CreateMap(this IGameControl control)
            => new Size(control.Size.Width + 2, control.Size.Height + 2)
                .CreateMap()
                .ToDictionary<Point, Point, IBlock>(x => x, x => (x.X, x.Y) switch {
                    (0, _) => new OutSide(x),
                    (_, 0) => new OutSide(x),
                    (var edge, _) when edge == control.Size.Height + 1 => new OutSide(x),
                    (_, var edge) when edge == control.Size.Width + 1 => new OutSide(x),
                    (_, _) => new Unknown(new Clear(x, control), control)
                });
                
        internal static IDictionary<Point, IBlock> SetBomb(this IDictionary<Point, IBlock> gameMap, IGameControl control, IBlock first)
            => RandomHelper.GetUInts(control.MineCount, control.Size.Width * control.Size.Height)
                .Aggregate(gameMap.Values.OfType<Unknown>().Except(new[] { first }), MoveToHead)
                .Take(control.MineCount)
                .ToArray()
                .AggregateAction(gameMap, (seed, block) => seed[block.Location] = new Unknown(new Bomb(block.Location, control), control));
        private static IEnumerable<IBlock> MoveToHead(IEnumerable<IBlock> blocks, int index)
        {
            var after = blocks.Skip(index - 1);
            var target = after.Take(1);
            return target.Concat(blocks.Take(index)).Concat(after.Skip(1));
        }

        private static readonly Point[] NEAR_RELATIVE_POSITION
            = CreateMap(new Size(3, 3), -1).ToArray();
        public static IEnumerable<Point> CreateMap(this Size size, int start = 0)
            => Enumerable.Range(start, size.Width)
                .SelectMany(x => Enumerable.Range(start, size.Height)
                    .Select(y => new Point(x, y)));

        public static IEnumerable<IBlock> GetNearBlocks(this IGameControl control, Point location)
            => NEAR_RELATIVE_POSITION.Select(p => new Point(location.X + p.X, location.Y + p.Y))
                .Select(control.GetBlock);
    }
}
