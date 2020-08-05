using System;
using System.Collections.Generic;
using System.Drawing;

namespace Mines
{

    public class Flag : IBlock
    {
        private readonly IBlock _block;
        private readonly IGameControl _control;

        public Flag(IBlock block, IGameControl control)
        {
            _block = block;
            _control = control;
        }
        public bool IsBomb => _block.IsBomb;
        public Point Location => _block.Location;
        public DisplayKind Display => DisplayKind.Flag;

        public IBlock Active() => this;
        public IBlock ToggleFlag()
            => _control.SetBlock(_block);
    }
}
