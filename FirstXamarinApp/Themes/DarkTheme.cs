using System;
using Xamarin.Forms;

namespace FirstXamarinApp.Themes
{
    public class DarkTheme : ThemeSetter
    {
        public override Color ButtonBackground => Color.BlueViolet;
        public override Color ButtonText => Color.BlanchedAlmond;

        public override Color AppBackground => Color.FromHex("#323232");
        public override Color LabelText => Color.FromHex("#ffffff");
        public override Color EntryBackground => Color.FromHex("#b2b2b2");
        public override Color BordersSeparators => Color.FromHex("#ffffff");
        public override Color Placeholders => Color.FromHex("#ffffff");
        public override Color EntryText => Color.FromHex("#000000");
        public override Color NavBar => Color.FromHex("#424242");
    }
}
