using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Personality> Personalities { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<FriendList> FriendLists { get; set; }
        //public virtual DbSet<FriendRequest> FriendRequests { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Visit>().HasKey(f => new { f.UserID, f.Visitor });
            modelBuilder.Entity<Visit>()
                .HasOne(f => f.User1)
                .WithMany()
                .HasForeignKey(f => f.UserID);
            modelBuilder.Entity<Visit>().HasOne(f => f.User2)
                .WithMany()
                .HasForeignKey(f => f.Visitor);


            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            //modelBuilder.Entity<User>().HasKey(x => x.Id);
            //modelBuilder.Entity<FriendList>().HasKey(x => x.FriendListID);

            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<FriendList>().ToTable("FriendLists");

            /* SEED DATA */
            //Categories
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Noobs" },
                new Category() { Id = 2, Name = "Pros" },
                new Category() { Id = 3, Name = "Omegaluls" }
                );


            //Games
            modelBuilder.Entity<Game>().HasData(
                new Game() { Id = 1, Name = "Dota 2", Publisher = "Valve" },
                new Game() { Id = 2, Name = "CS:GO", Publisher = "Valve" },
                new Game() { Id = 3, Name = "PUBG", Publisher = "Bluehole Corporation" }
                );

            //Genres
            modelBuilder.Entity<Genre>().HasData(
               new Genre() { Id = 1, Name = "MOBA" },
               new Genre() { Id = 2, Name = "FPS" },
               new Genre() { Id = 3, Name = "FPS" }
               );

            //Messages
            modelBuilder.Entity<Message>().HasData(
               new Message() { Id = 1, Text = "Hello muthafucka", RecieverId = 1, SenderId = 2, TimeStamp = DateTime.Now },
               new Message() { Id = 2, Text = "Check this shit out", RecieverId = 3, SenderId = 1, TimeStamp = DateTime.Now },
               new Message() { Id = 3, Text = "SKKRTSKRRRT", RecieverId = 2, SenderId = 1, TimeStamp = DateTime.Now }
               );

            //Nationalities
            modelBuilder.Entity<Nationality>().HasData(
              new Nationality() { Id = 1, Name = "Swedish" },
              new Nationality() { Id = 2, Name = "Norwegian" },
              new Nationality() { Id = 3, Name = "South African" }
              );

            //Personalities
            modelBuilder.Entity<Personality>().HasData(
              new Personality() { Id = 1, Description = "Cute" },
              new Personality() { Id = 2, Description = "Narcissistic" },
              new Personality() { Id = 3, Description = "Manipulative" }
              );

            //Platforms
            modelBuilder.Entity<Platform>().HasData(
              new Platform() { Id = 1, Name = "XBOX" },
              new Platform() { Id = 2, Name = "PS1" },
              new Platform() { Id = 3, Name = "PS3" }
              );

            //Posts
            modelBuilder.Entity<Post>().HasData(
               new Post() { Id = 1, RecieverId = 1, SenderId = 2, Text = "Holy shit dude.", TimeStamp = DateTime.Now },
               new Post() { Id = 2, RecieverId = 2, SenderId = 3, Text = "Holy shit dude.", TimeStamp = DateTime.Now },
               new Post() { Id = 3, RecieverId = 3, SenderId = 1, Text = "Holy shit dude.", TimeStamp = DateTime.Now }
               );

            //Statuses
            modelBuilder.Entity<Status>().HasData(
               new Status() { Id = 1, Description = "Pending", },
               new Status() { Id = 2, Description = "Accepted", },
                new Status() { Id = 3, Description = "Blocked", }

               );

            //Visitors
            modelBuilder.Entity<Visit>().HasData(
               new Visit() { UserID = 1, TimeStamp = DateTime.Now, Visitor = 1 },
               new Visit() { UserID = 2, TimeStamp = DateTime.Now, Visitor = 3 },
               new Visit() { UserID = 3, TimeStamp = DateTime.Now, Visitor = 2 }
               );

            //Users
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, FirstName = "Simon", LastName = "Bernsdorff Wallstedt", Mail = "simon.bernsdorff-wallstedt@dating.com", Age = 28, PreferedLanguage = "Swedish", Online = false, Gender = "Male", Active = true },
                new User() { Id = 2, FirstName = "Lukas", LastName = "Brolin", Mail = "lukas.broling@dating.com", Age = 27, PreferedLanguage = "Swedish", Online = false, Gender = "Male", Active = true },
                new User() { Id = 3, FirstName = "Filip", LastName = "Johansson", Mail = "filip.johansson@dating.com", Age = 27, PreferedLanguage = "Swedish", Online = false, Gender = "Male", Active = true });

        }
    
    }
}
