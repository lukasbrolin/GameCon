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

        //public IOrderedEnumerable<(User, List<Game>, List<Genre>, List<Platform>, int)> UserGamesGenrePlatforms { get; set; }

        public List<Game> Games { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Platform> Platforms { get; set; }

        public Nullable<int> Score { get; set; }

        public List<Visit> Visits { get; set; }
        public IList<User> Friends { get; set; }
        public List<Post> Posts { get; set; }
        public bool IsMatch { get; set; }
        public int IsFriend { get; set; }
    }
}