using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            var app = (App)Application.Current;
            Theme.IsToggled = app.CurrentTheme == "DarkTheme";
        }


        void ChangeTheme(object sender, ToggledEventArgs e)
        {
            Switch switcher = sender as Switch;
            var app = (App)Application.Current;

            if (switcher.IsToggled)
            {
                app.ChangeTheme("DarkTheme");
            } 
            else
            {
                app.ChangeTheme("LightTheme");
            }

        }
    }
}
