using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Friend
    {
        [Required]
        public virtual int FriendId { get; set; }

        [Required]
        public virtual int SenderId { get; set; }

        [Required]
        public virtual int ReceiverId { get; set; }

        [ForeignKey("SenderId")]
        [InverseProperty("Users")]
        public virtual User Sender { get; set; }

        [ForeignKey("ReceiverId")]
        [InverseProperty("Friends")]
        public virtual User Receiver { get; set; }

        [Required]
        public virtual int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public virtual int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
    }
}