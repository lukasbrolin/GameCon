using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Message
    {
        [Required]
        public virtual int MessageId { get; set; }
        [Required]
        public virtual int SenderId { get; set; }
        [Required]
        public virtual int ReceiverId { get; set; }
        [ForeignKey("SenderId")]
        [InverseProperty("MessagesSent")]
        public virtual User Sender { get; set; }
        [ForeignKey("ReceiverId")]
        [InverseProperty("MessagesReceived")]
        public virtual User Receiver { get; set; }
        [Required]
        public virtual DateTime TimeStamp { get; set; }

        public virtual string Content { get; set; }
    }
}