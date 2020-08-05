using System.Drawing;

namespace Mines
{
    public class OutSide : IBlock
    {
        public OutSide(Point location) {
            Location = location;
        }
        public DisplayKind Display => DisplayKind.OutSide;
        public Point Location { get; }
        public bool IsBomb => false;
        public IBlock Active() => this;
        public IBlock ToggleFlag() => this;
    }
}
