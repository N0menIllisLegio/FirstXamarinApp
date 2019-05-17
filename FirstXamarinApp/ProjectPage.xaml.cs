using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class ProjectPage : ContentPage
    {
        public ProjectPage()
        {
            InitializeComponent();
        }

        private async void ToEditProjectPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProjectPage());
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}
