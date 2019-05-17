using System;
using System.Linq;
using Realms;

namespace FirstXamarinApp.Schemas
{
    public class Project : RealmObject
    {
        [PrimaryKey]
        public string id { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        private string FinishDate { get; set; }
        public DateTime Deadline { get { return DateTime.Parse(FinishDate); } set { FinishDate = value.ToString("yyyy-MM-dd"); } }
        public string Description { get; set; }
        public int SkillLevel { get; set; }
        private string CreationDate { get; set; }
        public DateTime Created { get { return DateTime.Parse(CreationDate); } set { CreationDate = value.ToString("yyyy-MM-dd"); } }

        [Backlink(nameof(User.MyProjects))]
        public IQueryable<User> CreatedBy { get; }

        public Position ProjectPosition { get; set; }

        [Backlink(nameof(User.WorkingOnProjects))]
        public IQueryable<User> UsersWorking { get; }

    }
}
