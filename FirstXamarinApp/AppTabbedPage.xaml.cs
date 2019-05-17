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
        public User loggedUser;
        private string message = "";

        public AppTabbedPage(User user)
        {
            InitializeComponent();
            loggedUser = user;



            Children.Add(new NavigationPage(new AllProjectsPage(user))
            {
                Icon = "Projects.png",
                Title = "All projects"
            });

            Children.Add(new NavigationPage(new ProfilePage(user))
            {
                Icon = "Profile.png",
                Title = "Profile"
            });
        }

        private async void CheckNotifications()
        {
            foreach (Project project in loggedUser.WorkingOnProjects.ToList())
            {
                if (project.Deadline < DateTime.Now)
                {
                    message += project.Title + "\n";
                }
            }

            if (message != "")
            {
                DisplayMyAlert();
            } 
        } 

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckNotifications();
        }

        private async void DisplayMyAlert()
        {
            await DisplayAlert("Crossed Deadline!", message, "OK");
        }
    }
}
