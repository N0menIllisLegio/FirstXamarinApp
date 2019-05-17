using System;
using Realms;
using FirstXamarinApp.Schemas;
using System.Linq;
using System.Collections.Generic;

namespace FirstXamarinApp.Controllers
{
    public class UsersController
    {
        private Realm realm;
        private static UsersController usersController;
        public static UsersController SharedInstance { get
            {
                if (usersController == null)
                {
                    usersController = new UsersController();
                }

                return usersController;
            }
        }

        public List<User> GetAllUsers()
        {
            return new List<User>();
        }

        public User GetUser(string Login)
        {
            return realm.Find<User>(Login);
        }

        public bool RemoveUser(User user)
        {
            //realm.Remove(users.ToArray()[1]);
            return true;
        }

        public bool AddUser(User user)
        {
            bool success = true;
            try
            {
                realm.Write(() =>
                {
                    realm.Add(user);
                });
            }
            catch
            {
                success = false;
            }


            return success;
        }

        public bool UpdateUser(User user, User upd)
        {
            bool success = true;

            try
            {
                realm.Write(() =>
                {
                    upd.Name = user.Name;
                    upd.Age = user.Age;
                    upd.Surname = user.Surname;
                    upd.Password = user.Password;
                    upd.Age = user.Age;
                    upd.CurrentPosition = user.CurrentPosition;
                    upd.SkillLevel = user.SkillLevel;
                });
            }
            catch
            {
                success = false;
            }

            return success;
        }

        public bool AddToWorking(User user, Project project)
        {
            bool success = true;

            try
            {
                realm.Write(() =>
                {
                    user.WorkingOnProjects.Add(project);
                });
            }
            catch
            {
                success = false;
            }

            return success;
        }
        

        public bool RemoveFromWorking(User user, Project project)
        {
            bool success = true;

            try
            {
                realm.Write(() =>
                {
                    user.WorkingOnProjects.Remove(project);
                });
            }
            catch
            {
                success = false;
            }

            return success;
        }

        private UsersController()
        {
            this.realm = Realm.GetInstance();
        }
    }
}
