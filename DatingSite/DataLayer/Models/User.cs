using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataLayer.Models
{
    public class User
    {
        [Required]
        public virtual int Id { get; set; }
        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string LastName { get; set; }
        [Required]
        public virtual string Mail { get; set; }
        [Required]
        public virtual int Age { get; set; }
        [Required]
        public virtual string Gender { get; set; }
        [Required]
        public virtual Nationality Nationality { get; set; }
        [Required]
        public virtual string PreferedLanguage { get; set; }
        [Required]
        public virtual bool Online { get; set; }
        [Required]
        public virtual bool Active { get; set; }
        [Required]
        public virtual Personality Personality { get; set; }


        public virtual IList<Platform> Platforms { get; set; } = new List<Platform>();
        public virtual IList<Game> Games { get; set; } = new List<Game>();
        public virtual IList<Genre> Genres { get; set; } = new List<Genre>();
        public virtual IList<User> Friends { get; set; } = new List<User>();
        public virtual IList<User> Users { get; set; } = new List<User>();

        public User()
        {
        }

        
    }
}
