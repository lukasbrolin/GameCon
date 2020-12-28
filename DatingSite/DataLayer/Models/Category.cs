using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Category
    {
        [Required]
        public virtual int CategoryId { get; set; }

        [Required]
        public virtual string Name { get; set; }

    }
}