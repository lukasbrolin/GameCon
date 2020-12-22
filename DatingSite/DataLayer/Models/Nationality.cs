using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Nationality        
    {
        [Required]
        public virtual int NationalityId { get; set; }
        [Required]
        public virtual string Name { get; set; }
    }
}