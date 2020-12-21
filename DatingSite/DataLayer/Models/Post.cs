using System;

namespace DataLayer.Models
{
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual DateTime TimeStamp { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Reciever { get; set; }
        public virtual string Text { get; set; }

    }
}