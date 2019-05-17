using System.Linq;
using System.Collections.Generic;
using FirstXamarinApp.Schemas;
using FirstXamarinApp.Controllers;

namespace FirstXamarinApp
{
    public class SignUpPageViewModel : BaseViewModel
    {
        private List<Position> _listPositions;
        public List<Position> ListPositions
        {
            get 
            {
                return _listPositions; 
            }
            set 
            {
                SetProperty(ref _listPositions, value);
            }
        }

        public SignUpPageViewModel()
        {
            ListPositions = PositionsController.SharedInstance.GetAllPositions();
        }
    }
}
