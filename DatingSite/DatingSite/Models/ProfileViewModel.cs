using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DatingSite.Models
{
    public class ProfileViewModel
    {
        public User User { get; set; }
        public IList<User> Friends { get; set; }
        public IList<Post> Posts { get; set; }
        public IList<User> Visitors { get; set; }
        public IList<Game> Games { get; set; }
        public IList<Genre> Genres { get; set; }
        public IList<Platform> Platforms { get; set; }
        public bool IsMatch { get; set; }
        public int IsFriend { get; set; }
    }
}