using System;
using System.Linq;
using System.Collections.Generic;
using FirstXamarinApp.Controllers;
using FirstXamarinApp.Schemas;
using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class AddProjectPage : ContentPage
    {
        private User user;
        private Project project;
        private Project updProject;

        delegate void HandleSave(Project prj, Project updPrj, User usr);
        private HandleSave handleSave;
        public List<string> SkillLevels = new List<string> { "Junior", "Middle", "Senior", "Lead" };
        public List<string> Priorities = new List<string> { "Low", "Medium", "High" };

        public AddProjectPage(User user)
        {
            this.user = user;
            InitializeComponent();
            Skill.ItemsSource = SkillLevels;
            Priority.ItemsSource = Priorities;
            project = new Project();

            handleSave = (prj, updPrj, usr) =>
            {
                project.Created = DateTime.Now;
                if (ProjectsController.SharedInstance.AddProject(prj, usr))
                {
                    Navigation.PopAsync(true);
                }
                else
                {
                    DisplayAlert("Error!", "Somthing bad happened...", "OK");
                }
            };

            BindingContext = new PositionsViewModel();
        }

        public AddProjectPage(User user, Project project)
        {
            this.user = user;
            this.project = new Project();
            this.updProject = project;

            InitializeComponent();
            BindingContext = new PositionsViewModel();
            Skill.ItemsSource = SkillLevels;
            Priority.ItemsSource = Priorities;

            DEL.IsVisible = true;

            handleSave = (prj, updPrj, usr) =>
            {
                if (ProjectsController.SharedInstance.UpdateProject(prj, updPrj))
                {
                    Navigation.PopAsync(true);
                }
                else
                {
                    DisplayAlert("Error!", "Somthing bad happened...", "OK");
                }
            };

            Title.Text = project.Title;
            Description.Text = project.Description;
            Priority.SelectedIndex = project.Priority;
            Date.Date = project.Deadline;
            Skill.SelectedIndex = project.SkillLevel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as PositionsViewModel).ListPositions = PositionsController.SharedInstance.GetAllPositions();
        }

        private async void ToAddPostionPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPositionPage());
        }

        private void Save(object sender, EventArgs e)
        {
            project.Title = (Title.Text ?? "").Trim();
            project.Description = (Description.Text ?? "").Trim();
            project.Deadline = Date.Date;
            project.Priority = Priority.SelectedIndex;
            project.SkillLevel = Skill.SelectedIndex;

            if (PickedPosition.SelectedItem is Position)
            {
                project.ProjectPosition = PickedPosition.SelectedItem as Position;
            }

            if (project.Title != "" && project.Description != "" && project.Priority != -1 &&
                project.SkillLevel != -1 && project.ProjectPosition != null)
            {
                handleSave(project, updProject, user);
            }
            else
            {
                DisplayAlert("Error!", "All fields must be filled!", "OK");
            }
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            if (updProject.UsersWorking.ToList().Count == 0)
            {
                if (ProjectsController.SharedInstance.DeleteProject(updProject))
                {
                    Navigation.PopToRootAsync(true);
                }
                else
                {
                    DisplayAlert("Error", "Error", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Cant remove project that people working on!", "OK");
            }
        }
    }
}
