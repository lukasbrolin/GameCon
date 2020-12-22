using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Game
    {
        [Required]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Publisher { get; set; }

        public virtual IList<Genre> Genres { get; set; }
        public virtual IList<Platform> Platforms { get; set; }
        public virtual IList<User> Users { get; set; }

        public Game()
        {
            this.Genres = new List<Genre>();
            this.Platforms = new List<Platform>();
            this.Users = new List<User>();
        }
    }
}