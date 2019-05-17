using System;
using System.Linq;
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
        delegate void HandleSave(Position pos, Position upd);
        private HandleSave handleSave;

        private Position position;
        private Position updPosition;

        public AddPositionPage()
        {
            InitializeComponent();

            position = new Position();

            handleSave = (pos, upd) =>
            {
                if (PositionsController.SharedInstance.AddPosition(pos))
                {
                    Navigation.PopAsync(true);
                }
                else
                {
                    DisplayAlert("Error", "Such position already exist!", "OK");
                }
            };
        }

        public AddPositionPage(Position position)
        {
            InitializeComponent();

            position = new Position();
            updPosition = position;

            handleSave = (pos, upd) =>
            {
                if (PositionsController.SharedInstance.UpdatePosition(pos, upd))
                {
                    Navigation.PopAsync(true);
                }
                else
                {
                    DisplayAlert("Error", "Such position already exist!", "OK");
                }
            };

            Title.Text = position.Title;
            HexColor.Text = position.PositionColor;
            ColorDisplay.Color = Color.FromHex(position.PositionColor);

            var _A = (Convert.ToByte(position.PositionColor[1] + position.PositionColor[2] + "") / 255d);
            var _R = Convert.ToByte(position.PositionColor[3] + position.PositionColor[4] + "");
            var _G = Convert.ToByte(position.PositionColor[5] + position.PositionColor[6] + "");
            var _B = Convert.ToByte(position.PositionColor[7] + position.PositionColor[8] + "");

            A.Value = _A / 255d;
            R.Value = _B / 255d;
            G.Value = _G / 255d;
            B.Value = _B / 255d;

            ALabel.Text = $"Alpha = {_A:P1}";
            RLabel.Text = $"Red = {_R}";
            GLabel.Text = $"Green = {_G}"; 
            BLabel.Text = $"Blue = {_B}";
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

        private void Remove(object sender, EventArgs e)
        {
            if (updPosition.UsersOnPosition.ToList().Count == 0)
            {
                if (PositionsController.SharedInstance.RemovePosition(updPosition))
                {
                    Navigation.PopToRootAsync(true);
                }
                else
                {
                    DisplayAlert("Error", "Error", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Cant remove position that people working on!", "OK");
            }
        }

        private void Save(object sender, EventArgs e)
        {
            position.Title = (Title.Text ?? "").Trim();
            position.PositionColor = HexColor.Text;

            if (position.Title != "" && position.PositionColor.Length == 9)
            {
                handleSave(position, updPosition);
            }
            else
            {
                DisplayAlert("Error!", "All fields must be filled!", "OK");
            }
        }
    }
}
