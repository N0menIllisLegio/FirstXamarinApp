using FirstXamarinApp.Controllers;
using FirstXamarinApp.Schemas;
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
            BindingContext = new PositionsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as PositionsViewModel).ListPositions = PositionsController.SharedInstance.GetAllPositions();
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
            if (CurrPos.SelectedItem != null)
            {
                var temp = CurrPos.SelectedItem as Position;
                await Navigation.PushAsync(new AddPositionPage(temp.id));
            } 
            else
            {
                await DisplayAlert("Warning", "Nothing to configure", "OK");
            }

        }

        private async void ToAddPositionPage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddPositionPage() { Title = "Add Position"});
        }

        private async void ToSignInPage(object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
