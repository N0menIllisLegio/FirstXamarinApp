using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class SignUpPage : ContentPage
    {
        public List<string> SkillLevels = new List<string> { "Junior", "Middle", "Senior", "Lead" };

        public SignUpPage()
        {
            InitializeComponent();
            Skill.ItemsSource = SkillLevels;
        }

        private async void ToAddPositionPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddPositionPage());
        }
    }
}
