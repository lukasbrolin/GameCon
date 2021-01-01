using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Models
{
    public class CardViewModel
    {
        public List<User> Users { get; set; }

        public IOrderedEnumerable<(User, List<Game>, List<Genre>, List<Platform>, int)> UserGamesGenrePlatforms { get; set; }
    }
}