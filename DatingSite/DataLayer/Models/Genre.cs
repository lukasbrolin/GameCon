using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<User> Users { get; set; }
        public IList<Game> Games { get; set; }

        public Genre()
        {
            this.Users = new List<User>();
            this.Games = new List<Game>();
        }
    }
}