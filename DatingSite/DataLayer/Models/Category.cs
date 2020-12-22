using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Category
    {
        [Required]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        //public virtual IList<FriendList> FriendLists { get; set; }

        public Category()
        {
            //this.FriendLists = new List<FriendList>();
        }
    }
}