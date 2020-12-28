using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class User
    {
        [Required]
        public virtual int UserId { get; set; }

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
        public virtual int NationalityId { get; set; }

        [Required]
        public virtual string ImgUrl { get; set; }

        [ForeignKey("NationalityId")]
        public virtual Nationality Nationality { get; set; }

        [Required]
        public virtual string PreferedLanguage { get; set; }

        [Required]
        public virtual bool Online { get; set; }

        [Required]
        public virtual bool Active { get; set; }

        [Required]
        public virtual int PersonalityId { get; set; }

        [ForeignKey("PersonalityId")]
        public virtual Personality Personality { get; set; }

        public virtual IList<Platform> Platforms { get; set; } = new List<Platform>();
        public virtual IList<Game> Games { get; set; } = new List<Game>();
        public virtual IList<Genre> Genres { get; set; } = new List<Genre>();
        public virtual IList<Friend> Friends { get; set; } = new List<Friend>();
        public virtual IList<Friend> Users { get; set; } = new List<Friend>();
        public virtual IList<Post> PostsReceived { get; set; } = new List<Post>();
        public virtual IList<Post> PostsSent { get; set; } = new List<Post>();
        public virtual IList<Visit> Visitors { get; set; } = new List<Visit>();
        public virtual IList<Visit> MyVisits { get; set; } = new List<Visit>();
        public virtual IList<Message> MessagesReceived { get; set; } = new List<Message>();
        public virtual IList<Message> MessagesSent { get; set; } = new List<Message>();
    }
}