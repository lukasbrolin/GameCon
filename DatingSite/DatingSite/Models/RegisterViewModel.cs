using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "First name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last name:")]
        public virtual string LastName { get; set; }

        [Display(Name = "Age:")]
        public virtual int Age { get; set; }

        [Display(Name = "Gender:")]
        public virtual string Gender { get; set; }

        [Display(Name = "Nationality:")]
        public virtual int Nationality { get; set; }

        [Display(Name = "Language:")]
        public virtual string Language { get; set; }

        [Display(Name = "Personality:")]
        public virtual int Personality { get; set; }
    }
}