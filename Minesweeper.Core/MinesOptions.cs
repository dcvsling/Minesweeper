using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Minesweeper
{
    public readonly ref struct MinesweeperOptions
    {
        public MinesweeperOptions(Size size, int count)
        {
            Size = size;
            MineCount = count;
        }
        public Size Size { get; }
        public int MineCount { get; }
    }
}
