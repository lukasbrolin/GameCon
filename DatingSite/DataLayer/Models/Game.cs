using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public IList<Genre> Genres { get; set; }
        public IList<Platform> Platforms { get; set; }
        public IList<User> Users { get; set; }

        public Game()
        {
            this.Genres = new List<Genre>();
            this.Platforms = new List<Platform>();
            this.Users = new List<User>();
        }
    }
}