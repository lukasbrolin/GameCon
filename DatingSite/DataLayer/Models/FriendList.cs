using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataLayer.Models
{
    public class FriendList
    {
        public int FriendListID { get; set; }
        //public IList<User> Users1 { get; set; }
        //public IList<User> Users2 { get; set; }
        public DateTime TimeStamp { get; set; }

        public FriendList()
        {
            //this.Users1 = new List<User>();
            //this.Users2 = new List<User>();
        }
    }

}
