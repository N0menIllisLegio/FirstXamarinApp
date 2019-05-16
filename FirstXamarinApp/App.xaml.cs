using Xamarin.Forms;
using System.Collections.Generic;
using FirstXamarinApp.Themes;

namespace FirstXamarinApp
{
    public partial class App : Application
    {
        private Dictionary<string, ThemeSetter> Themes = new Dictionary<string, ThemeSetter>();
        public string CurrentTheme { get; private set; }

        public void ChangeTheme(string theme)
        {
            Themes[theme].SetTheme();
            CurrentTheme = theme;
        }

        private void LoadThemes()
        {
            Themes.Add("LightTheme", new LightTheme());
            Themes.Add("DarkTheme", new DarkTheme());
        }

        public App()
        {
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule());
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule());
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule());
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.IoniconsModule());
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.WeatherIconsModule());
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.MaterialModule());

            InitializeComponent();
            LoadThemes();
            ChangeTheme("DarkTheme");

            MainPage = new NavigationPage(new SignInPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
