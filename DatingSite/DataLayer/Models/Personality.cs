using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Personality
    {
        [Required]
        public virtual int PersonalityId { get; set; }
        [Required]
        public virtual string Description { get; set; }
    }
}