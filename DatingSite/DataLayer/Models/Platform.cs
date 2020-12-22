using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Platform
    {
        [Required]
        public virtual int PlatformId { get; set; }
        [Required]
        public virtual string Name { get; set; }

        public virtual IList<Game> Games { get; set; } = new List<Game>();
        public virtual IList<User> Users { get; set; } = new List<User>();

    }
}