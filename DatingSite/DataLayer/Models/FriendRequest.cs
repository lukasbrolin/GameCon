//using System;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace DataLayer.Models
//{
//    public class FriendRequest
//    {
//        public virtual int SenderId { get; set; }
//        public virtual int RecieverId { get; set; }
//        [ForeignKey("SenderId")]
//        public virtual User User1 { get; set; }
//        [ForeignKey("RecieverID")]
//        public virtual User User2 { get; set; }
//        public virtual DateTime TimeStamp { get; set; }
//        public virtual bool Pending { get; set; }

//    }
//}