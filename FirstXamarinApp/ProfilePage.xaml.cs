using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using FirstXamarinApp.Schemas;

namespace FirstXamarinApp
{
    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }

    public partial class ProfilePage : ContentPage
    {
        public List<string> SkillLevels = new List<string> { "Junior", "Middle", "Senior", "Lead" };
        private User user;

        public ProfilePage(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Name.Text = user.Name;
            Surname.Text = user.Surname;
            Age.Text = user.Age.ToString("dd, MMMM yyyy");
            CurrentPosition.Text = user.CurrentPosition.Title;
            CurrentPosition.TextColor = Color.FromHex(user.CurrentPosition.PositionColor);
            Skill.Text = SkillLevels[user.SkillLevel];

            var collection = new Grouping<string, Project>("MY PROJECTS", user.MyProjects.ToList());
            var UsersGrouped = new ObservableCollection<Grouping<string, Project>>();
            UsersGrouped.Add(collection);

            collection = new Grouping<string, Project>("WORKING ON", user.WorkingOnProjects.ToList());
            UsersGrouped.Add(collection);

            ProjectsList.ItemsSource = UsersGrouped;
            ProjectsList.GroupDisplayBinding = new Binding("Key");
        }

        private async void ToEditProfilePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage(user) { Title = "Edit User"});
        }
    }
}
