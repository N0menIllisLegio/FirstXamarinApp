using System.ComponentModel;
using Xamarin.Forms;
using Realms;
using FirstXamarinApp.Schemas;
using System.Linq;

namespace FirstXamarinApp
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private void RealmConf()
        {
            var realm = Realm.GetInstance();
            var user = new User();
            var users = realm.All<User>();

            myLabel.Text = "Before: " + users.Count();

            realm.Write(() =>
            {
                realm.Add(new User { Name = "Rex", Age = 1, Owner = "Test" });
            });

            myLabel.Text += "\nAfter: " + users.Count();
        }

        public MainPage()
        {
            InitializeComponent();
            RealmConf();
        }
    }
}
