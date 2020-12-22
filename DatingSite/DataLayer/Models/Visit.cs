using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Visit
    {
        [Required]
        public virtual int VisitId { get; set; }
        [Required]
        public virtual int SenderId { get; set; }
        [Required]
        public virtual int ReceiverId { get; set; }
        [ForeignKey("SenderId")]
        [InverseProperty("MyVisits")]
        public virtual User Sender { get; set; }
        [ForeignKey("ReceiverId")]
        [InverseProperty("Visitors")]
        public virtual User Receiver { get; set; }
        [Required]
        public virtual DateTime TimeStamp { get; set; }

    }
}