using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Mines
{
    public readonly ref struct MinesOptions
    {
        public MinesOptions(Size size, int count)
        {
            Size = size;
            MineCount = count;
        }
        public Size Size { get; }
        public int MineCount { get; }
    }
}
