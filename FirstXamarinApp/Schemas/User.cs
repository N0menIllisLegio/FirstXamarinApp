using System;
using Realms;

namespace FirstXamarinApp.Schemas
{
    public class User : RealmObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }
    }
}
