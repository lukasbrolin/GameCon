using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Nationality        
    {
        [Required]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}