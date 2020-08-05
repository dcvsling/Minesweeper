using System.Drawing;
using Xunit;

namespace Mines.Tests
{
    public class GameControlTests
    {
        [Fact]
        public void Test1()
        {
            var control = new MinesOptions(new Size(10, 10), 10).CreateControl();
            var block = control.GetBlock(new Point(3, 4)).ToggleFlag();
            
            Assert.Equal(DisplayKind.Flag, block.Display);
            block = block.ToggleFlag();
            Assert.Equal(DisplayKind.UnKnown, block.Display);
        }
    }

    public class HelperTests
    {
        [Fact]
        public void get_near_position_will_get_3x3_block()
        {
            var control = new MinesOptions(new Size(10, 10), 10).CreateControl();
            do
            {
                control.Reset();
                control.CreateMap();
                var block = control.GetBlock(new Point(3, 4));
                block.Active();
            } while (control.GetBlock(new Point(3, 4)).Display != DisplayKind.Clear);
        }
    }
}
