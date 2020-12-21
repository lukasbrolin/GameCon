using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Mail { get; set; }
        public virtual int Age { get; set; }
        public virtual string Gender { get; set; }
        public virtual Country Country { get; set; }
        public virtual string PreferedLanguage { get; set; }
        public virtual bool Online { get; set; }
        public virtual bool Active { get; set; }
        //public IList<User> Friends { get; set; }
        //public IList<FriendList> Friends { get; set; }
        public virtual Personality Personality { get; set; }
        public virtual IList<Platform> Platforms { get; set; }
        public virtual IList<Game> Games { get; set; }
        public virtual IList<Genre> Genres { get; set; }

        public User()
        {
            //this.UserID = new List<FriendList>();
            //this.Friend = new List<FriendList>();
            this.Platforms = new List<Platform>();
            this.Games = new List<Game>();
            this.Genres = new List<Genre>();
        }

        
    }
}
