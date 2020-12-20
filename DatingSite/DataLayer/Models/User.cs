using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Country Country { get; set; }
        //public IList<User> Friends { get; set; }
        //public IList<FriendList> Friends { get; set; }
        public Personality Personality { get; set; }
        public IList<Platform> Platforms { get; set; }
        public IList<Game> Games { get; set; }
        public IList<Genre> Genres { get; set; }

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
