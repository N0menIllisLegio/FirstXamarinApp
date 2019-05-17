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
        public List<string> SkillLevels = new List<string> { "1. Junior", "2. Middle", "3. Senior", "4. Lead" };
        delegate void HandleSave();
        private HandleSave handleSave;

        private List<string> positions = new List<string>();
        private User user;

        public SignUpPage()
        {
            InitializeComponent();
            Skill.ItemsSource = SkillLevels;
            user = new User();

            handleSave = () => 
            {
                if (UsersController.SharedInstance.AddUser(user))
                {
                    Navigation.PopAsync(true);
                }
                else
                {
                    DisplayAlert("Error!", "User with such login already exists!", "OK");
                }
            };

            BindingContext = new SignUpPageViewModel();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as SignUpPageViewModel).ListPositions = PositionsController.SharedInstance.GetAllPositions();
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
                    handleSave();
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
