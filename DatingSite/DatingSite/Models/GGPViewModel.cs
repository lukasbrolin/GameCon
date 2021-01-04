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

        public List<Game> Games { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Platform> Platforms { get; set; }


    }

}
