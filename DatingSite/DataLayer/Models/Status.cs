using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Status
    {
        [Required]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}