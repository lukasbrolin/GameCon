using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DatingSite.Models
{
    public class GGPViewModel
    {
        public Dictionary<Game, bool> Games { get; set; }

        public Dictionary<Genre, bool> Genres { get; set; }

        public Dictionary<Platform, bool> Platforms { get; set; }

        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Nick name")]
        public string NickName { get; set; }

        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last name")]
        public virtual string LastName { get; set; }

        [Range(1, 99, ErrorMessage = "Age must be between 1-99.")]
        [Display(Name = "Age")]
        public virtual int Age { get; set; }

        [Display(Name = "Gender")]
        public virtual string Gender { get; set; }

        [Display(Name = "Nationality")]
        public virtual string Nationality { get; set; }

        [Display(Name = "Personality")]
        public virtual string Personality { get; set; }

        [Display(Name = "Image")]
        public virtual string ImgURL { get; set; }
    }
}