using System;
using System.Collections.Generic;
using System.Linq;
using FirstXamarinApp.Schemas;
using Realms;

namespace FirstXamarinApp.Controllers
{
    public class ProjectsController
    {
        private Realm realm;
        private static ProjectsController projectsController;
        public static ProjectsController SharedInstance
        {
            get
            {
                if (projectsController == null)
                {
                    projectsController = new ProjectsController();
                }

                return projectsController;
            }
        }

        public List<Project> GetAllProjects()
        {

            return realm.All<Project>().ToList();
        }

        private ProjectsController()
        {
            this.realm = Realm.GetInstance();
        }
    }
}
