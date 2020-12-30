using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Models
{
    public class MatchViewModel
    {
        public MatchViewModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public List<Game> Games { get; set; }
    }
}