using System;
using System.Collections.Generic;
using System.Linq;
using FirstXamarinApp.Controllers;
using FirstXamarinApp.Schemas;
using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class ProjectPage : ContentPage
    {
        private Project project;
        private User user;

        public ProjectPage(Project project, User user)
        {
            this.project = project;
            this.user = user;
            InitializeComponent();
            BindingContext = new UsersViewModel();
        }

        private void ReloadUsers()
        {
            (BindingContext as UsersViewModel).ListUsers = project.UsersWorking.ToList();
            EditButton.IsEnabled = project.CreatedBy.Any(_user => _user.Login == user.Login);

            if (project.UsersWorking.Any(_user => _user.Login == user.Login))
            {
                WorkButton.Text = "Leave Project";
            }
            else
            {
                WorkButton.Text = "Join Project";
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Title.Text = project.Title;
            Description.Text = project.Description;
            Created.Text = project.Created.ToString("dd, MMMM yyyy");
            Deadline.Text = project.Deadline.ToString("dd, MMMM yyyy");
            CreatedBy.Text = project.CreatedBy.FirstOrDefault().Surname + " " + project.CreatedBy.FirstOrDefault().Name;
            switch (project.Priority)
            {
                case 0:
                    Priority.BackgroundColor = Color.Green;
                    break;
                case 1:
                    Priority.BackgroundColor = Color.Yellow;
                    break;
                case 2:
                    Priority.BackgroundColor = Color.Red;
                    break;
                default:
                    Priority.BackgroundColor = Color.Gray;
                    break;
            }

            ReloadUsers();
        }

        private async void ToEditProjectPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProjectPage(user, project) { Title = "Edit Project"});
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }

        private void Handle_click(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "Join Project")
            {
                UsersController.SharedInstance.AddToWorking(user, project);
                WorkButton.Text = "Leave Project";
            }
            else
            {

                UsersController.SharedInstance.RemoveFromWorking(user, project);
                WorkButton.Text = "Join Project";
            }

            ReloadUsers();
        }

    }
}
