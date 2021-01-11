using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Models
{
    public class RegisterViewModel
    {
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Required]
        [Display(Name = "Nick name")]
        public string NickName { get; set; }

        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Required]
        [Display(Name = "Last name")]
        public virtual string LastName { get; set; }

        [Range(1, 99, ErrorMessage = "Age must be between 1-99.")]
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

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public virtual string ImageURL { get; set; }
    }
}