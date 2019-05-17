using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstXamarinApp.Schemas;
using FirstXamarinApp.Controllers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppTabbedPage : TabbedPage
    {
        public const string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        public User loggedUser;

        public AppTabbedPage(User user)
        {
            InitializeComponent();
            loggedUser = user;
            Children.Add(new NavigationPage(new AllProjectsPage(user))
            {
                Icon = "Projects.png",
                Title = "All projects"
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayMyAlert();
        }

        private async void DisplayMyAlert()
        {
            await DisplayAlert("Alert", lorem + lorem + lorem + lorem, "OK");
        }
    }
}
