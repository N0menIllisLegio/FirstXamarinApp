using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

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

    public class NewUser
    {
        public string Name { get; set; }
        public string Proffesion { get; set; }
    }

    public partial class ProfilePage : ContentPage
    {
        List<NewUser> users = new List<NewUser>();

        public ProfilePage()
        {
            InitializeComponent();


            users.Add(new NewUser
            {
                Name = "1",
                Proffesion = "1"
            });
            users.Add(new NewUser
            {
                Name = "2",
                Proffesion = "2"
            });


            var collection = new Grouping<string, NewUser>("MY PROJECTS", users);
            var UsersGrouped = new ObservableCollection<Grouping<string, NewUser>>();
            UsersGrouped.Add(collection);

            collection = new Grouping<string, NewUser>("WORKING ON", users);
            UsersGrouped.Add(collection);

            ProjectsList.ItemsSource = UsersGrouped;
            ProjectsList.GroupDisplayBinding = new Binding("Key");
        }

        private async void ToEditProfilePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ProjectPage());
        }
    }
}
