using System;

namespace DataLayer.Models
{
    class Message
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public User Sender { get; set; }
        public User Reciever { get; set; }
        public string Text { get; set; }
    }
}