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

        public List<User> GetAllUsers()
        {
            return new List<User>();
        }

        public User GetUser(int Login)
        {
            return new User();
        }

        public bool RemoveUser(User user)
        {
            return true;
        }

        public bool AddUser(User user)
        {
            var users = realm.All<User>();

            realm.Write(() =>
            {
                realm.Add(new User { id = 2, Name = "Masha" });
                //realm.Remove(users.ToArray()[1]);
            });

            return true;
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
