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

        private async void ToEditPositionPage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddPositionPage());
        }

        private async void ToAddPositionPage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddPositionPage());
        }

        private async void ToSignInPage(object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
