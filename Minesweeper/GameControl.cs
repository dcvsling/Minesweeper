using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Mines
{
    [DebuggerDisplay("{DebugView}")]
    public class GameControl : IGameControl
    {
        private readonly IDictionary<Point, IBlock> _gameMap;
        private Action<IBlock> _setBomb;
        
        public GameControl(MinesOptions options)
        {
            Size = options.Size;
            MineCount = options.MineCount;
            _setBomb = SetFirstBomb;
            _gameMap = this.CreateMap();
        }
        public Size Size { get; }
        public int MineCount { get; }
        public int FlagCount => MineCount - FlagLocation.Count;
        public IList<Point> FlagLocation { get; } = new List<Point>();

        public IBlock GetBlock(Point location) => _gameMap[location];
        public void SetFlag(IBlock block)
        {
            FlagLocation.Add(block.Location);
            _gameMap[block.Location] = new Flag(block, this);
        }
        public void ActiveBlock(IBlock block)
        {
            _gameMap[block.Location] = block;
            block.Active();
        }
        public IBlock SetBlock(IBlock block) => _gameMap[block.Location] = block;
        public void HitBomb(Point location) => _gameMap.Values.Each(b => b.Active());
        public Action<IBlock> SetBomb => _setBomb;

        private void SetFirstBomb(IBlock first)
        {
            _setBomb = _ => { };
            _gameMap.SetBomb(this, first);
        }

        public void Reset()
        {
            _gameMap.Clear();
            this.CreateMap().Each(x => _gameMap.Add(x.Key, x.Value));
        }

        internal string DebugView
            => string.Join(Environment.NewLine, _gameMap.Values.GroupBy(x => x.Location.Y, x => x.Display.ChangeDisplay)
                .Select(x => string.Concat(x)));
    }
}
