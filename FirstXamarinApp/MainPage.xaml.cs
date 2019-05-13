using System.ComponentModel;
using Xamarin.Forms;

namespace FirstXamarinApp
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    { 
        public MainPage()
        {
            InitializeComponent();
        }
    }
}

// Add file FodyWeavers.xml, dependences: Fody 3.3.5 and Realm to Android
// Duplicate dependences from Main to IOS and Android