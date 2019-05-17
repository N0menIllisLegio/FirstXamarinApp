using System;
using Xamarin.Forms;

namespace FirstXamarinApp.Themes
{
    public class LightTheme : ThemeSetter
    {
        public override Color ButtonBackground => Color.Gray;
        public override Color ButtonText => Color.White;

        public override Color AppBackground => Color.FromHex("ffffffff");
        public override Color LabelText => Color.FromHex("#000000");
        public override Color EntryBackground => Color.FromHex("#ffffff");
        public override Color BordersSeparators => Color.FromHex("#000000");
        public override Color Placeholders => Color.FromHex("#505050");
        public override Color EntryText => Color.FromHex("#000000");
        public override Color NavBar => Color.FromHex("#c1c1c1");
    }
}
