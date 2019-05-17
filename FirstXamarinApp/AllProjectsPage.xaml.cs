using System;
using System.Linq;
using System.Collections.Generic;
using FirstXamarinApp.Schemas;
using FirstXamarinApp.Controllers;

using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class AllProjectsPage : ContentPage
    {
        private User user;

        public AllProjectsPage(User user)
        {
            this.user = user;
            InitializeComponent();
            BindingContext = new AllProjectsPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var projects = ProjectsController.SharedInstance.GetAllProjects();

            projects = projects.Where((project) => project.SkillLevel <= user.SkillLevel).ToList();

            projects.Sort(delegate (Project x, Project y)
            {
                return x.Priority.CompareTo(y.Priority);
            });

            (BindingContext as AllProjectsPageViewModel).ListProjects = projects;

        }

        private async void ToAddProjectPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProjectPage(user) { Title = "Add Project" });
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ProjectPage(AllProjectsList.SelectedItem as Project, user));
        }
    }
}
