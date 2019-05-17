using System;
using System.Collections.Generic;
using FirstXamarinApp.Controllers;
using FirstXamarinApp.Schemas;

namespace FirstXamarinApp
{
    public class AllProjectsPageViewModel : BaseViewModel
    {
        private List<Project> _listProjects;
        public List<Project> ListProjects
        {
            get
            {
                return _listProjects;
            }
            set
            {
                SetProperty(ref _listProjects, value);
            }
        }

        public AllProjectsPageViewModel()
        {
            ListProjects = ProjectsController.SharedInstance.GetAllProjects();
        }
    }
}
