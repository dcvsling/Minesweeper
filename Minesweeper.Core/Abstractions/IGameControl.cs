using System;
using System.Collections.Generic;
using System.Drawing;

namespace Minesweeper
{

    public interface IGameControl
    {
        IBlock GetBlock(Point location);
        IBlock SetBlock(IBlock block);
        Size Size { get; }
        int MineCount { get; }
        int FlagCount { get; }
        IList<Point> FlagLocation { get; }
        void HitBomb(Point location);
        void SetFlag(IBlock block);
        void ActiveBlock(IBlock block);
        Action<IBlock> SetBomb { get; }
        void Reset();
    }
}
