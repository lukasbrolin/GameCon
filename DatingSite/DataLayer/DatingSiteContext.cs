using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.IdentityModel.Tokens;

namespace DataLayer
{
    public class DatingSiteContext : DbContext
    {
        public DatingSiteContext(DbContextOptions<DatingSiteContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
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

            //modelBuilder.Entity<Visit>().HasKey(f => new { f.ReceiverId, f.SenderId });
            //modelBuilder.Entity<Visit>()
            //    .HasOne(f => f.Receiver)
            //    .WithMany()
            //    .HasForeignKey(f => f.ReceiverId);
            //modelBuilder.Entity<Visit>().HasOne(f => f.Sender)
            //    .WithMany()
            //    .HasForeignKey(f => f.SenderId);

            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            //modelBuilder.Entity<User>().HasKey(x => x.Id);
            //modelBuilder.Entity<FriendList>().HasKey(x => x.FriendListID);

            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<FriendList>().ToTable("FriendLists");

            /* SEED DATA */
            //Categories
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name = "Noobs" },
                new Category() { CategoryId = 2, Name = "Pros" },
                new Category() { CategoryId = 3, Name = "Omegaluls" }
                );

            //Game
            modelBuilder.Entity<Game>().HasData(
                new Game() { GameId = 1, Name = "Dota 2", Publisher = "Valve" },
                new Game() { GameId = 2, Name = "CS:GO", Publisher = "Valve" },
                new Game() { GameId = 3, Name = "PUBG", Publisher = "Bluehole Corporation" }
                );

            //Genre
            modelBuilder.Entity<Genre>().HasData(
               new Genre() { GenreId = 1, Name = "MOBA" },
               new Genre() { GenreId = 2, Name = "FPS" },
               new Genre() { GenreId = 3, Name = "FPS" }
               );

            //GameGenre
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Genres)
                .WithMany(g => g.Games)
                .UsingEntity(j => j.ToTable("GameGenre")
                .HasData(new { GenresGenreId = 1, GamesGameId = 3 })
               );

            //GamePlatform
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Platforms)
                .WithMany(g => g.Games)
                .UsingEntity(j => j.ToTable("GamePlatform")
                .HasData(new { PlatformsPlatformId = 3, GamesGameId = 1 })
               );

            //GameUser
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Users)
                .WithMany(g => g.Games)
                .UsingEntity(j => j.ToTable("GameUser")
                .HasData(new { UsersUserId = 3, GamesGameId = 1 })
               );

            //GenreUser
            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Users)
                .WithMany(g => g.Genres)
                .UsingEntity(j => j.ToTable("GenreUser")
                .HasData(new { UsersUserId = 2, GenresGenreId = 3 })
               );

            //PlatformUser
            modelBuilder.Entity<Platform>()
                .HasMany(g => g.Users)
                .WithMany(g => g.Platforms)
                .UsingEntity(j => j.ToTable("PlatformUser")
                .HasData(new { UsersUserId = 3, PlatformsPlatformId = 2 })
               );


            ////UserUser
            //modelBuilder.Entity<User>()
            //    .HasMany(g => g.Users)
            //    .WithMany(g => g.Users)
            //    .UsingEntity(j => j.ToTable("UserUser")
            //    .HasData(new { UserId = 3, FriendsId = 2 })
            //   );


            //modelBuilder.Entity<User>()
            //    .HasMany(p => p.Users)
            //    .WithMany(p => p.Friends)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "UserUser",
            //        j => j
            //            .HasOne<User>()
            //            .WithMany()
            //            .HasForeignKey("UserId")
            //            .HasConstraintName("FK_UserUser_Users_UserId")
            //            .OnDelete(DeleteBehavior.Cascade),
            //        j => j
            //            .HasOne<User>()
            //            .WithMany()
            //            .HasForeignKey("FriendId")
            //            .HasConstraintName("FK_UserUser_Users_FriendId")
            //            .OnDelete(DeleteBehavior.ClientCascade))
            //            .HasData(new { UserId = 3, FriendId = 2, CategoryId = 1, StatusId = 1});

            //Message
            modelBuilder.Entity<Message>().HasData(
               new Message() { MessageId = 1, Content = "Hello muthafucka", ReceiverId = 1, SenderId = 2, TimeStamp = DateTime.Now },
               new Message() { MessageId = 2, Content = "Check this shit out", ReceiverId = 3, SenderId = 1, TimeStamp = DateTime.Now },
               new Message() { MessageId = 3, Content = "SKKRTSKRRRT", ReceiverId = 2, SenderId = 1, TimeStamp = DateTime.Now }
               );

            //Nationalitie
            modelBuilder.Entity<Nationality>().HasData(
              new Nationality() { NationalityId = 1, Name = "Swedish" },
              new Nationality() { NationalityId = 2, Name = "Norwegian" },
              new Nationality() { NationalityId = 3, Name = "South African" }
              );

            //Personalitie
            modelBuilder.Entity<Personality>().HasData(
              new Personality() { PersonalityId = 1, Description = "Cute" },
              new Personality() { PersonalityId = 2, Description = "Narcissistic" },
              new Personality() { PersonalityId = 3, Description = "Manipulative" },
              new Personality() { PersonalityId = 4, Description = "Strategist" }

              );

            //Platform
            modelBuilder.Entity<Platform>().HasData(
              new Platform() { PlatformId = 1, Name = "XBOX" },
              new Platform() { PlatformId = 2, Name = "PS1" },
              new Platform() { PlatformId = 3, Name = "PS3" },
              new Platform() { PlatformId = 4, Name = "PC" },
              new Platform() { PlatformId = 5, Name = "PS5" }


              );

            //Friend
            modelBuilder.Entity<Friend>().HasData(
                new Friend() { FriendId = 1, SenderId = 1, ReceiverId = 2, CategoryId = 1, StatusId = 1},
                new Friend() { FriendId = 2, SenderId = 2, ReceiverId = 3, CategoryId = 2, StatusId = 2},
                new Friend() { FriendId = 3, SenderId = 3, ReceiverId = 1, CategoryId = 1, StatusId = 2}
            );

            //Post
            modelBuilder.Entity<Post>().HasData(
               new Post() { PostId = 1, ReceiverId = 1, SenderId = 2, Content = "Holy shit dude.", TimeStamp = DateTime.Now },
               new Post() { PostId = 2, ReceiverId = 2, SenderId = 3, Content = "Holy shit dude.", TimeStamp = DateTime.Now },
               new Post() { PostId = 3, ReceiverId = 3, SenderId = 1, Content = "Holy shit dude.", TimeStamp = DateTime.Now }
               );

            //Statuse
            modelBuilder.Entity<Status>().HasData(
               new Status() { StatusId = 1, Description = "Pending", },
               new Status() { StatusId = 2, Description = "Accepted", },
               new Status() { StatusId = 3, Description = "Blocked", }

               );

            //Visitor
            modelBuilder.Entity<Visit>().HasData(
               new Visit() { VisitId = 1, ReceiverId = 1, TimeStamp = DateTime.Now, SenderId = 1 },
               new Visit() { VisitId = 2, ReceiverId = 2, TimeStamp = DateTime.Now, SenderId = 3 },
               new Visit() { VisitId = 3, ReceiverId = 3, TimeStamp = DateTime.Now, SenderId = 2 }
               );

            //User
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, NationalityId = 1, PersonalityId = 1, FirstName = "Simon", LastName = "Bernsdorff Wallstedt", Mail = "simon.bernsdorff-wallstedt@dating.com", Age = 28, PreferedLanguage = "Swedish", Online = false, Gender = "Male", Active = true },
                new User() { UserId = 2, NationalityId = 1, PersonalityId = 2, FirstName = "Lukas", LastName = "Brolin", Mail = "lukas.brolin@dating.com", Age = 27, PreferedLanguage = "Swedish", Online = false, Gender = "Male", Active = true },
                new User() { UserId = 3, NationalityId = 1, PersonalityId = 3, FirstName = "Filip", LastName = "Johansson", Mail = "filip.johansson@dating.com", Age = 27, PreferedLanguage = "Swedish", Online = false, Gender = "Male", Active = true },
                new User() { UserId = 4, NationalityId = 1, PersonalityId = 4, FirstName = "Magnus", LastName = "Karlsson", Mail = "magnus.karlsson@dating.com", Age = 22, PreferedLanguage = "English", Online = false, Gender = "Male", Active = true });
        }
    }
}