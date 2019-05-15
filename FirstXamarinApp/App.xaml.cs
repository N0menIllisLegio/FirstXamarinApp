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
