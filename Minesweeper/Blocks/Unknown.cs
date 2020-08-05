using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Mines
{
    public class Unknown : IBlock
    {
        private readonly IBlock _block;
        private readonly IGameControl _control;
        private static Func<IBlock, IBlock> _active;
        public Unknown(IBlock block, IGameControl control)
        {
            _block = block;
            _control = control;
            _active = Initialize;
        }
        public bool IsBomb => _block.IsBomb;
        public Point Location => _block.Location;
        public DisplayKind Display => DisplayKind.UnKnown;

        public IBlock Active()
            => _active(_block);

        private IBlock ActiveBlock(IBlock block)
        {
            _control.SetBlock(block);
            _control.SetBomb(block);
            block = block.Active();
            if(block.Display == DisplayKind.Clear)
                _control.GetNearBlocks(block.Location).Each(b => b.Active());
            return block;
        }

        private IBlock Initialize(IBlock first)
        {
            _control.SetBomb(first);
            _active = ActiveBlock;
            return _active(first);
        }

        public IBlock ToggleFlag()
            => _control.SetBlock(new Flag(this, _control));
    }
}
