using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void ToAddPositionPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddPositionPage());
        }
    }
}
