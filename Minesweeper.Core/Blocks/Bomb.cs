using System;
using System.Collections.Generic;
using System.Drawing;

namespace Minesweeper
{

    public class Bomb : IBlock
    {
        internal readonly IGameControl _control;

        public Bomb(Point location, IGameControl control)
        {
            _control = control;
            Location = location;
        }

        public Point Location { get; }
        public DisplayKind Display => DisplayKind.Bomb;

        public bool IsBomb => true;

        public IBlock Active()
        {
            _control.SetBlock(this);
            _control.HitBomb(Location);
            return this;
        }
        public IBlock ToggleFlag()
        {
            _control.FlagLocation.Add(Location);
            return _control.SetBlock(new Flag(this, _control));
        }
    }
}
