using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FirstXamarinApp
{
    public class Project
    {
        public string Name = "";
        public string Location = "";
    }

    public partial class AllProjectsPage : ContentPage
    {
        public IList<Project> Projects { get; private set; }

        public AllProjectsPage()
        {
            InitializeComponent();
            Projects = new List<Project>();

            Projects.Add(new Project
            {
                Name = "Pr1",
                Location = "Lc1"
            });
        }
    }
}
