using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataLayer.Models
{
    public class FriendList
    {
        public virtual int UserId { get; set; }
        public virtual int Friend { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public DateTime TimeStamp { get; set; }

        public FriendList()
        {
            //this.Friend = new List<User>();
        }
    }

}
