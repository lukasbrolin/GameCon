using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Models
{
    public class GGPViewModel
    {
        public User User { get; set; }

        public Dictionary<Game, bool> Games { get; set; }

        public Dictionary<Genre, bool> Genres { get; set; }

        public Dictionary<Platform, bool> Platforms { get; set; }

        public virtual string ImageURL { get; set; }



    }

}
