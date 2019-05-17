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

        private bool locker = false;

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

        public AddPositionPage(string id)
        {
            InitializeComponent();

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

            var posi = PositionsController.SharedInstance.GetPosition(id);

            this.position = new Position();
            updPosition = posi;

            locker = true;
            Title.Text = updPosition.Title;
            HexColor.Text = updPosition.PositionColor;
            PositionColor = Color.FromHex(updPosition.PositionColor);

            A.Value = Color.FromHex(updPosition.PositionColor).A;
            R.Value = Color.FromHex(updPosition.PositionColor).R;
            G.Value = Color.FromHex(updPosition.PositionColor).G;
            B.Value = Color.FromHex(updPosition.PositionColor).B;

            ALabel.Text = $"Alpha = {Color.FromHex(updPosition.PositionColor).A:P1}";
            RLabel.Text = $"Red = {Math.Round(Color.FromHex(updPosition.PositionColor).R * 255)}";
            GLabel.Text = $"Green = {Math.Round(Color.FromHex(updPosition.PositionColor).G * 255)}"; 
            BLabel.Text = $"Blue = {Math.Round(Color.FromHex(updPosition.PositionColor).B * 255)}";
            locker = false;
        }

        public void OnSliderValueChanged(object sender, EventArgs e)
        {
            if (sender is Slider && !locker)
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
