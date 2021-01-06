using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Serialize
{
    public class SerializeProfile
    {
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ImgUrl { get; set; }
        public string Nationality { get; set; }
        public string Personality { get; set; }
        public IList<Game> Games { get; set; }
        public IList<Genre> Genres { get; set; }
        public IList<Platform> Platforms { get; set; }
    }
}
