using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public virtual string LastName { get; set; }

        [Required]
        [Display(Name = "Age")]
        public virtual int Age { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public virtual string Gender { get; set; }

        [Required]
        [Display(Name = "Language")]
        public virtual string Language { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public virtual string Nationality { get; set; }

        [Required]
        [Display(Name = "Personality")]
        public virtual string Personality { get; set; }

        [Display(Name = "Image")]
        public virtual string ImageURL { get; set; }
    }
}