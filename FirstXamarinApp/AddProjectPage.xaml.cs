using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class AddProjectPage : ContentPage
    {
        public AddProjectPage()
        {
            InitializeComponent();
        }

        private async void ToAddPostionPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPositionPage());
        }
    }
}
