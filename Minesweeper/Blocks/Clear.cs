using System.Drawing;
using System.Linq;

namespace Mines
{

    public class Clear : IBlock
    {
        private readonly IGameControl _control;
        public Clear(Point location, IGameControl control)
        {
            _control = control;
            Location = location;
        }
        public Point Location { get; }
        public DisplayKind Display
            => NearBombCount != 0
                ? DisplayKind.MineCount[NearBombCount - 1]
                : DisplayKind.Clear;

        private int NearBombCount
            => _control.GetNearBlocks(Location)
                    .Where(x => x.IsBomb)
                    .Count();
                

        public bool IsBomb => false;
        public IBlock Active() => this;

        public IBlock ToggleFlag() => this;
    }
}
