using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Models
{
    public class GameViewModel
    {
        public GameViewModel(string name)
        {
            this.Name = name;
        }
        [Display(Name = "Game")]
        public string Name { get; set; }

        public GameViewModel(string name)
        {
            this.Name = name;
        }
    }


}