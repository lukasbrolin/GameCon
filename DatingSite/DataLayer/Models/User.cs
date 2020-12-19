using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Country Country { get; set; }

    }
}
