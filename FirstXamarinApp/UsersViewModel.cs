using System;
using System.Collections.Generic;
using FirstXamarinApp.Controllers;
using FirstXamarinApp.Schemas;

namespace FirstXamarinApp
{
    public class UsersViewModel : BaseViewModel
    {
        public UsersViewModel()
        {
            //ListUsers = Projec.SharedInstance.GetAllPositions();
        }

        private List<User> _listUsers;
        public List<User> ListUsers
        {
            get
            {
                return _listUsers;
            }
            set
            {
                SetProperty(ref _listUsers, value);
            }
        }
    }
}
