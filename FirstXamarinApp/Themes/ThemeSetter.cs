using System;
using Xamarin.Forms;

namespace FirstXamarinApp.Themes
{
    public abstract class ThemeSetter
    {
        public abstract Color ButtonBackground { get; }
        public abstract Color ButtonText { get; }

        //public abstract Color PageBackground { get; set; }

        //public abstract Color LabelText { get; set; }

        //public abstract Color EntryBackground { get; set; }
        //public abstract Color EntryText { get; set; }
        //public abstract Color EntryPlaceholder { get; set; }

        // NavBar Buttons and Title

        public virtual void SetTheme()
        {
            Application.Current.Resources["ButtonBackground"] = ButtonBackground;
            Application.Current.Resources["ButtonText"] = ButtonText;
        }
    }
}
