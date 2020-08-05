using System;
using System.Collections.Generic;
using System.Drawing;

namespace Mines
{

    public interface IBlock
    {
        Point Location { get; }
        DisplayKind Display { get; }
        bool IsBomb { get; }
        IBlock Active();
        IBlock ToggleFlag();
    }
}
