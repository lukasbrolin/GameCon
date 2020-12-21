using System;

namespace DataLayer.Models
{
    public class Visit
    {
        public virtual int UserID { get; set; }
        public virtual int Visitor { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public virtual DateTime TimeStamp { get; set; }

    }
}