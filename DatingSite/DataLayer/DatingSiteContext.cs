using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DataLayer
{
    public class DatingSiteContext : DbContext
    {
        public DatingSiteContext(DbContextOptions<DatingSiteContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Personality> Personalities { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<Category> Categories { get; set; }
    }
}
