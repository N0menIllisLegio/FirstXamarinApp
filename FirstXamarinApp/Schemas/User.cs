using System;
using System.Collections.Generic;
using Realms;

namespace FirstXamarinApp.Schemas
{
    public class User : RealmObject
    {
        [PrimaryKey]
        public string Login { get; set; } = "";
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        private string BirthDate { get; set; }
        public DateTime Age { get { return DateTime.Parse(BirthDate);  } set { BirthDate = value.ToString("yyyy-MM-dd"); } }
        public int SkillLevel { get; set; }

        //Relationships
        public Position CurrentPosition { get; set; }
        public IList<Project> MyProjects { get; }
        public IList<Project> WorkingOnProjects { get; }
    }
}