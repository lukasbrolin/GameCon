using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<FriendList> FriendLists { get; set; }

        public Category()
        {
            this.FriendLists = new List<FriendList>();
        }
    }
}