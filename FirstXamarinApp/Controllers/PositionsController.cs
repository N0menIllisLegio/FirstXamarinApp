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

            position.id = Guid.NewGuid().ToString();

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

        public bool UpdatePosition(Position position, Position upd)
        {
            bool success = true;

            try
            {
                realm.Write(() =>
                {
                    upd.Title = position.Title;
                    upd.PositionColor = position.PositionColor;
                });
            }
            catch
            {
                success = false;
            }

            return success;
        }

        public bool RemovePosition(Position position)
        {
            bool success = true;

            try
            {
                realm.Write(() =>
                {
                    realm.Remove(position);
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

        public Position GetPosition(string id)
        {
            //var temp =realm.All<Position>().ToList();
            return realm.Find<Position>(id);
        }

        private PositionsController()
        {
            this.realm = Realm.GetInstance();
        }
    }
}
