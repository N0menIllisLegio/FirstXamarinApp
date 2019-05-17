using System.Linq;
using System.Collections.Generic;
using FirstXamarinApp.Schemas;
using FirstXamarinApp.Controllers;

namespace FirstXamarinApp
{
    public class PositionsViewModel : BaseViewModel
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

        private Position _selectedPosition;
        public Position SelectedPosition
        {
            get
            {
                return _selectedPosition;
            }
            set
            {
                if (value != null)
                    SetProperty(ref _selectedPosition, value);
            }
        }

        public PositionsViewModel()
        {
            ListPositions = PositionsController.SharedInstance.GetAllPositions();
        }
    }
}
