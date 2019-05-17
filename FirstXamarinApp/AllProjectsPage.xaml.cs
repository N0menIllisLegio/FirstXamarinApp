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

            var pr = new List<Project>();
            pr.Add(new Project
            {
                Title = "Title2",
                Deadline = new DateTime(),
                Priority = 2,
                SkillLevel = 1
            });
            pr.Add(new Project
            {
                Title = "Title1",
                Deadline = new DateTime(),
                Priority = 1,
                SkillLevel = 2
            });
            pr.Add(new Project
            {
                Title = "Title3",
                Deadline = new DateTime(),
                Priority = 3,
                SkillLevel = 3
            });

            //ProjectsController.SharedInstance.GetAllProjects();
            //filter
            pr = pr.Where((project) => project.SkillLevel <= user.SkillLevel).ToList();

            pr.Sort(delegate (Project x, Project y)
            {
                return x.Priority.CompareTo(y.Priority);
            });

            (BindingContext as AllProjectsPageViewModel).ListProjects = pr;

        }

        private async void ToAddProjectPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProjectPage());
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ProjectPage());
        }
    }
}
