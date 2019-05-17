using System;
using System.Linq;
using System.Collections.Generic;
using FirstXamarinApp.Schemas;
using FirstXamarinApp.Controllers;

using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class SignUpPage : ContentPage
    {
        public List<string> SkillLevels = new List<string> { "Junior", "Middle", "Senior", "Lead" };
        delegate void HandleSave(User usr, User updUsr);
        private HandleSave handleSave;

        private User user;
        private User updUser;

        public SignUpPage()
        {
            InitializeComponent();
            Skill.ItemsSource = SkillLevels;
            user = new User();

            handleSave = (usr, updUsr) => 
            {
                if (UsersController.SharedInstance.AddUser(usr))
                {
                    Navigation.PopAsync(true);
                }
                else
                {
                    DisplayAlert("Error!", "User with such login already exists!", "OK");
                }
            };

            Login.IsReadOnly = false;
            BindingContext = new PositionsViewModel();
        }

        public SignUpPage(User user)
        {
            InitializeComponent();
            Skill.ItemsSource = SkillLevels;
            this.user = new User();
            updUser = user;

            handleSave = (usr, updUsr) =>
            {
                if (UsersController.SharedInstance.UpdateUser(usr, updUsr))
                {
                    Navigation.PopAsync(true);
                }
                else
                {
                    DisplayAlert("Error!", "User with such login already exists!", "OK");
                }
            };

            BindingContext = new PositionsViewModel();
            Login.Text = user.Login;
            Name.Text = user.Name;
            Surname.Text = user.Surname;
            Date.Date = user.Age;
            Skill.SelectedIndex = user.SkillLevel;

            Login.IsReadOnly = true;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as PositionsViewModel).ListPositions = PositionsController.SharedInstance.GetAllPositions();
        }

        private async void ToAddPositionPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPositionPage());
        }

        private void Save(object sender, EventArgs e)
        {
            user.Login = (Login.Text ?? "").Trim();
            user.Password = (Password.Text ?? "").Trim();
            string repass = (rePassword.Text ?? "").Trim();
            user.Name = (Name.Text ?? "").Trim();
            user.Surname = (Surname.Text ?? "").Trim();
            user.Age = Date.Date;

            if (PickedPosition.SelectedItem is Position)
            {
                user.CurrentPosition = PickedPosition.SelectedItem as Position;
            }

            user.SkillLevel = Skill.SelectedIndex;

            if (user.Login != "" && user.Password != "" && user.Name != "" && 
                user.Surname != "" && user.CurrentPosition != null && user.SkillLevel != -1)
            {
                if (user.Password == repass)
                {
                    if (updUser == null || user.SkillLevel >= updUser.SkillLevel)
                    {
                        handleSave(user, updUser);
                    }
                    else
                    {
                        DisplayAlert("Error!", "You cant downcast your skill!", "OK");
                    }
                }
                else 
                {
                    DisplayAlert("Error!", "Passwords doesn't match!", "OK");
                }
            }
            else
            {
                DisplayAlert("Error!", "All fields must be filled!", "OK");
            }
        }
    }
}
