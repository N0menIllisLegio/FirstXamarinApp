using System;
using Realms;
using System.Linq;
using FirstXamarinApp.Schemas;
using System.Collections.Generic;

namespace FirstXamarinApp.Controllers
{
    public class PositionsController
    {
        private Realm realm;
        private static PositionsController positionsController;
        public static PositionsController SharedInstance
        {
            get
            {
                if (positionsController == null)
                {
                    positionsController = new PositionsController();
                }

                return positionsController;
            }
        }

        public bool AddPosition(Position position)
        {
            bool success = true;

            try
            {
                realm.Write(() =>
                {
                    realm.Add(position);
                });
            }
            catch
            {
                success = false;
            }

            return success;
        }

        public List<Position> GetAllPositions()
        {
            return realm.All<Position>().ToList();
        }

        private PositionsController()
        {
            this.realm = Realm.GetInstance();
        }
    }
}
