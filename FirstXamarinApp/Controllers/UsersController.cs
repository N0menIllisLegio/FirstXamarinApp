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

        public bool UpdateUser(User user)
        {
            return true;
        }

        private UsersController()
        {
            this.realm = Realm.GetInstance();
        }
    }
}
