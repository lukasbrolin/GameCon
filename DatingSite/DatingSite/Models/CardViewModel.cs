using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Models
{
    public class CardViewModel
    {
        //public CardViewModel(string name)
        //{
        //    Name = name;
        //}

        public List<User> Users { get; set; }

        public List<(User, List<Game>, List<Genre>, List<Platform>)> UserGamesGenrePlatforms { get; set; }
    }
}