using Realms;

namespace FirstXamarinApp.Schemas
{
    public class User : RealmObject
    {
        [PrimaryKey]
        public string Login { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public string Role { get; set; }
        public string Avatar { get; set; }
    }
}

//  ???