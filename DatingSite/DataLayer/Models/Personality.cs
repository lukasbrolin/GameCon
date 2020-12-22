using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Personality
    {
        [Required]
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
    }
}