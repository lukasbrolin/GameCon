using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Post
    {
        [Required]
        public virtual int Id { get; set; }
        public virtual int SenderId { get; set; }

        public virtual int RecieverId { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Reciever { get; set; }
        public virtual DateTime TimeStamp { get; set; }
        public virtual string Text { get; set; }

    }
}