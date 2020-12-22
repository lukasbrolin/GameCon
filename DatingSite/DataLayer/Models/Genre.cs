using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Genre
    {
        [Required]
        public virtual int GenreId { get; set; }
        [Required]
        public virtual string Name { get; set; }


        public virtual IList<User> Users { get; set; } = new List<User>();
        public virtual IList<Game> Games { get; set; } = new List<Game>();

    }
}