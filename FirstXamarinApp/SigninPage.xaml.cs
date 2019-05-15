using System.ComponentModel;
using Xamarin.Forms;
using System;

namespace FirstXamarinApp
{
    [DesignTimeVisible(true)]
    public partial class SignInPage : ContentPage
    { 
        public SignInPage()
        {
            InitializeComponent();
        }
        private async void ToTabbedPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void ToSignUpPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}

/*
 Add file FodyWeavers.xml, dependences: Fody 3.3.5 and Realm to Android
 Duplicate dependences from Main to IOS and Android
 
 Roles: Junior, Middle, Senior, Lead
 
 ColorPicker settings for Positions:
 
 xaml
    xmlns:cp="clr-namespace:Amporis.Xamarin.Forms.ColorPicker;assembly=Amporis.Xamarin.Forms.ColorPicker" 
    <cp:ColorPickerMixer Color = "{Binding EditedColor}" />

 c#
    private Color editedColor;

    public Color EditedColor
    {
        get => editedColor;
        set { editedColor = value; OnPropertyChanged(); }
    }

 Add IOS safe area:
    xmlns:ios="clr-namespace:Xamarin.Forms.PlatformConfiguration.iOSSpecific;assembly=Xamarin.Forms.Core" 
    ios:Page.UseSafeArea="true"
       
 Add Lines breaks on buttons, labels etc.
*/
