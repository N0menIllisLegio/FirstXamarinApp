using System;
using FirstXamarinApp.Controllers;
using FirstXamarinApp.Schemas;
using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class AddPositionPage : ContentPage
    {
        //"#00FFFFFF"
        private Color _positionColor;
        private Color PositionColor { get { return _positionColor; } set { ColorDisplay.Color = value; _positionColor = value; } }
        delegate void HandleSave();
        private HandleSave handleSave;

        private Position position;

        public AddPositionPage()
        {
            InitializeComponent();

            position = new Position();

            handleSave = () =>
            {
                if (PositionsController.SharedInstance.AddPosition(position))
                {
                    Navigation.PopAsync(true);
                }
                else
                {
                    DisplayAlert("Error", "Such position already exist!", "OK");
                }
            };
        }

        public void OnSliderValueChanged(object sender, EventArgs e)
        {
            if (sender is Slider)
            {
                Slider slider = sender as Slider;
                byte red = (byte)Math.Round(PositionColor.R * 255);
                byte green = (byte)Math.Round(PositionColor.G * 255);
                byte blue = (byte)Math.Round(PositionColor.B * 255);
                byte alpha = (byte)Math.Round(PositionColor.A * 255);

                HexColor.Text = $"#{alpha:X2}{red:X2}{green:X2}{blue:X2}";

                if (sender == R)
                {
                    PositionColor = new Color(slider.Value, PositionColor.G, PositionColor.B, PositionColor.A);
                    RLabel.Text = $"Red = {red}";
                }
                if (sender == G)
                {
                    PositionColor = new Color(PositionColor.R, slider.Value, PositionColor.B, PositionColor.A);
                    GLabel.Text = $"Green = {green}";
                }
                if (sender == B)
                {
                    PositionColor = new Color(PositionColor.R, PositionColor.G, slider.Value, PositionColor.A);
                    BLabel.Text = $"Blue = {blue}";
                }
                if (sender == A)
                {
                    PositionColor = new Color(PositionColor.R, PositionColor.G, PositionColor.B, slider.Value);
                    ALabel.Text = $"Alpha = {(alpha / 255d):P1}";
                }
            }
        }

        private void Save(object sender, EventArgs e)
        {
            position.Title = (Title.Text ?? "").Trim();
            position.PositionColor = HexColor.Text;

            if (position.Title != "" && position.PositionColor.Length == 9)
            {
                handleSave();
            }
            else
            {
                DisplayAlert("Error!", "All fields must be filled!", "OK");
            }
        }
    }
}
