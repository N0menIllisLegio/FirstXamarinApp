using System;
using Xamarin.Forms;

namespace FirstXamarinApp.Themes
{
    public abstract class ThemeSetter
    {
        public abstract Color ButtonBackground { get; }
        public abstract Color ButtonText { get; }

        public abstract Color AppBackground { get; }

        public abstract Color LabelText { get; }

        public abstract Color EntryBackground { get; }
        public abstract Color BordersSeparators { get; }
        public abstract Color Placeholders { get; }
        public abstract Color EntryText { get; }

        public abstract Color NavBar { get; }

        // NavBar Buttons and Title

        public virtual void SetTheme()
        {
            Application.Current.Resources["ButtonBackground"] = ButtonBackground;
            Application.Current.Resources["ButtonText"] = ButtonText;
            Application.Current.Resources["AppBackground"] = AppBackground;
            Application.Current.Resources["LabelText"] = LabelText;
            Application.Current.Resources["EntryBackground"] = EntryBackground;
            Application.Current.Resources["BordersSeparators"] = BordersSeparators;
            Application.Current.Resources["Placeholders"] = Placeholders;
            Application.Current.Resources["EntryText"] = EntryText;
            Application.Current.Resources["NavBar"] = NavBar;
        }
    }
}
