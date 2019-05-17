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

        public bool AddProject(Project project, User user)
        {
            bool success = true;

            project.id = Guid.NewGuid().ToString();

            try
            {
                realm.Write(() =>
                {
                    realm.Add(project);
                    user.MyProjects.Add(project);
                    realm.Add(user, true);
                });
            }
            catch
            {
                success = false;
            }


            return success;
        }

        public bool UpdateProject(Project project, Project upd)
        {
            bool success = true;

            try
            {
                realm.Write(() =>
                {
                    upd.Title = project.Title;
                    upd.Description = project.Description;
                    upd.Deadline = project.Deadline;
                    upd.Priority = project.Priority;
                    upd.SkillLevel = project.SkillLevel;
                    upd.ProjectPosition = project.ProjectPosition;
                });
            }
            catch
            {
                success = false;
            }

            return success;
        }

        public bool DeleteProject(Project project)
        {
            bool success = true;

            try
            {
                realm.Write(() =>
                {
                    realm.Remove(project);
                });
            }
            catch
            {
                success = false;
            }

            return success;
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
