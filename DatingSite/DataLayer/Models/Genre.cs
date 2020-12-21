using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Genre
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<User> Users { get; set; }
        public virtual IList<Game> Games { get; set; }

        public Genre()
        {
            this.Users = new List<User>();
            this.Games = new List<Game>();
        }
    }
}