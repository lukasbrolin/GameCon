using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Status
    {
        [Required]
        public int StatusId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}