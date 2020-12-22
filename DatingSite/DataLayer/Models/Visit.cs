using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Visit
    {
        [Required]
        public virtual int UserID { get; set; }
        [Required]
        public virtual int Visitor { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public virtual DateTime TimeStamp { get; set; }

    }
}