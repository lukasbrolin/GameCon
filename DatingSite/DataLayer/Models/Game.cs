using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Game
    {
        [Required]
        public virtual int GameId { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Publisher { get; set; }

        public virtual IList<Genre> Genres { get; set; } = new List<Genre>();
        public virtual IList<Platform> Platforms { get; set; } = new List<Platform>();
        public virtual IList<User> Users { get; set; } = new List<User>();
    }
}