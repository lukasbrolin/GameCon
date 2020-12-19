using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Game> Games { get; set; }
        public IList<User> Users { get; set; }

    }
}