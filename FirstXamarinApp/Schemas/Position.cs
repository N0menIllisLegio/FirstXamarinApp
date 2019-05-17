using System;
using System.Linq;
using Realms;

namespace FirstXamarinApp.Schemas
{
    public class Position : RealmObject
    {
        [PrimaryKey]
        public string Title { get; set; }
        public string PositionColor { get; set; }

        [Backlink(nameof(User.CurrentPosition))]
        public IQueryable<User> UsersOnPosition { get; }
    }
}
