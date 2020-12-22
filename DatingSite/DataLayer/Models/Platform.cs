using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Platform
    {
        [Required]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Game> Games { get; set; }
        public virtual IList<User> Users { get; set; }

        public Platform()
        {
            this.Games = new List<Game>();
            this.Users = new List<User>();
        }
    }
}