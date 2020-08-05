namespace Mines
{
    public class DisplayKind
    {
        public static DisplayKind Bomb { get; set; } = new DisplayKind("Ｂ");
        public static DisplayKind[] MineCount => new[] {
            new DisplayKind("１"),
            new DisplayKind("２"),
            new DisplayKind("３"),
            new DisplayKind("４"),
            new DisplayKind("５"),
            new DisplayKind("６"),
            new DisplayKind("７"),
            new DisplayKind("８"),
        };
        public static DisplayKind UnKnown { get; set; } = new DisplayKind("■");
        public static DisplayKind Clear { get; set; } = new DisplayKind("　");
        public static DisplayKind Flag { get; set; } = new DisplayKind("F");
        public static DisplayKind OutSide { get; set; } = new DisplayKind("");
        public string ChangeDisplay { get; }

        public DisplayKind(string text)
        {
            ChangeDisplay = text;
        }
    }
}
