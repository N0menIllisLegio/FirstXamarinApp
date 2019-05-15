using System;

using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class AddPositionPage : ContentPage
    {
        //"#00FFFFFF"
        private Color _positionColor;
        private Color PositionColor { get { return _positionColor; } set { ColorDisplay.Color = value; _positionColor = value; } }

        public AddPositionPage()
        {
            InitializeComponent();
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
                    ALabel.Text = $"Alpha = {alpha / 255d * 100} %";
                }


            }
        }
    }
}
