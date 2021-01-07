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
                new Game() { GameId = 2, Name = "CSGO", Publisher = "Valve" },
                new Game() { GameId = 3, Name = "PUBG", Publisher = "Bluehole Corporation" },
                new Game() { GameId = 4, Name = "World of Warcraft", Publisher = "Blizzard" },
                new Game() { GameId = 5, Name = "Among us", Publisher = "InnerSloth" }
                );

            //Genre
            modelBuilder.Entity<Genre>().HasData(
               new Genre() { GenreId = 1, Name = "MOBA" },
               new Genre() { GenreId = 2, Name = "FPS" },
               new Genre() { GenreId = 3, Name = "Explore" },
               new Genre() { GenreId = 4, Name = "King of the hill" },
               new Genre() { GenreId = 5, Name = "MMO" },
               new Genre() { GenreId = 6, Name = "Strategy" },
               new Genre() { GenreId = 7, Name = "Open world"}

               );

            //GameGenre
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Genres)
                .WithMany(g => g.Games)
                .UsingEntity(j => j.ToTable("GameGenre")
                .HasData(
                new { GenresGenreId = 1, GamesGameId = 1 },
                new { GenresGenreId = 6, GamesGameId = 1 },
                new { GenresGenreId = 2, GamesGameId = 2 },
                new { GenresGenreId = 6, GamesGameId = 2 },
                new { GenresGenreId = 2, GamesGameId = 3 },
                new { GenresGenreId = 4, GamesGameId = 3 },
                new { GenresGenreId = 6, GamesGameId = 3 },
                new { GenresGenreId = 7, GamesGameId = 3 },
                new { GenresGenreId = 3, GamesGameId = 4 },
                new { GenresGenreId = 5, GamesGameId = 4 },
                new { GenresGenreId = 7, GamesGameId = 4 },
                new { GenresGenreId = 6, GamesGameId = 5 })
               );

            //GamePlatform
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Platforms)
                .WithMany(g => g.Games)
                .UsingEntity(j => j.ToTable("GamePlatform")
                .HasData(new { PlatformsPlatformId = 3, GamesGameId = 1 },
                new { PlatformsPlatformId = 1, GamesGameId = 2 },
                new { PlatformsPlatformId = 2, GamesGameId = 2 },
                new { PlatformsPlatformId = 3, GamesGameId = 2 },
                new { PlatformsPlatformId = 3, GamesGameId = 3 },
                new { PlatformsPlatformId = 3, GamesGameId = 4 },
                new { PlatformsPlatformId = 3, GamesGameId = 5 })
               );

            //GameUser
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Users)
                .WithMany(g => g.Games)
                .UsingEntity(j => j.ToTable("GameUser")
                .HasData(new { UsersUserId = 3, GamesGameId = 1 },
                new { UsersUserId = 1, GamesGameId = 1 },
                new { UsersUserId = 1, GamesGameId = 2 },
                new { UsersUserId = 1, GamesGameId = 3 },
                new { UsersUserId = 2, GamesGameId = 1 },
                new { UsersUserId = 2, GamesGameId = 2 },
                new { UsersUserId = 2, GamesGameId = 3 },
                new { UsersUserId = 2, GamesGameId = 4 },
                new { UsersUserId = 3, GamesGameId = 2 },
                new { UsersUserId = 3, GamesGameId = 3 },
                new { UsersUserId = 4, GamesGameId = 1 },
                new { UsersUserId = 4, GamesGameId = 2 },
                new { UsersUserId = 4, GamesGameId = 4 },
                new { UsersUserId = 4, GamesGameId = 5 },
                new { UsersUserId = 5, GamesGameId = 1 },
                new { UsersUserId = 5, GamesGameId = 4 },
                new { UsersUserId = 5, GamesGameId = 5 },
                new { UsersUserId = 6, GamesGameId = 2 },
                new { UsersUserId = 6, GamesGameId = 3 },
                new { UsersUserId = 6, GamesGameId = 4 },
                new { UsersUserId = 7, GamesGameId = 4 },
                new { UsersUserId = 8, GamesGameId = 1 },
                new { UsersUserId = 8, GamesGameId = 4 },
                new { UsersUserId = 8, GamesGameId = 5 },
                new { UsersUserId = 9, GamesGameId = 1 },
                new { UsersUserId = 10, GamesGameId = 2 },
                new { UsersUserId = 11, GamesGameId = 2 },
                new { UsersUserId = 11, GamesGameId = 4 })
               );

            //GenreUser
            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Users)
                .WithMany(g => g.Genres)
                .UsingEntity(j => j.ToTable("GenreUser")
                .HasData(new { UsersUserId = 1, GenresGenreId = 1 },
                new { UsersUserId = 1, GenresGenreId = 2 },
                new { UsersUserId = 1, GenresGenreId = 3 },
                new { UsersUserId = 2, GenresGenreId = 4 },
                new { UsersUserId = 2, GenresGenreId = 1 },
                new { UsersUserId = 2, GenresGenreId = 2 },
                new { UsersUserId = 3, GenresGenreId = 4 },
                new { UsersUserId = 3, GenresGenreId = 5 },
                new { UsersUserId = 3, GenresGenreId = 6 },
                new { UsersUserId = 4, GenresGenreId = 1 },
                new { UsersUserId = 4, GenresGenreId = 4 },
                new { UsersUserId = 4, GenresGenreId = 7 },
                new { UsersUserId = 5, GenresGenreId = 1 },
                new { UsersUserId = 5, GenresGenreId = 2 },
                new { UsersUserId = 5, GenresGenreId = 3 },
                new { UsersUserId = 6, GenresGenreId = 1 },
                new { UsersUserId = 6, GenresGenreId = 2 },
                new { UsersUserId = 6, GenresGenreId = 6 },
                new { UsersUserId = 7, GenresGenreId = 2 },
                new { UsersUserId = 8, GenresGenreId = 3 },
                new { UsersUserId = 9, GenresGenreId = 4 },
                new { UsersUserId = 10, GenresGenreId = 3 },
                new { UsersUserId = 10, GenresGenreId = 4 },
                new { UsersUserId = 11, GenresGenreId = 4 },
                new { UsersUserId = 11, GenresGenreId = 5 },
                new { UsersUserId = 11, GenresGenreId = 7 })
               );

            //PlatformUser
            modelBuilder.Entity<Platform>()
                .HasMany(g => g.Users)
                .WithMany(g => g.Platforms)
                .UsingEntity(j => j.ToTable("PlatformUser")
                .HasData(new { UsersUserId = 1, PlatformsPlatformId = 3 },
                new { UsersUserId = 1, PlatformsPlatformId = 2 },
                new { UsersUserId = 2, PlatformsPlatformId = 3 },
                new { UsersUserId = 3, PlatformsPlatformId = 3 },
                new { UsersUserId = 3, PlatformsPlatformId = 1 },
                new { UsersUserId = 4, PlatformsPlatformId = 1 },
                new { UsersUserId = 4, PlatformsPlatformId = 3 },
                new { UsersUserId = 5, PlatformsPlatformId = 3 },
                new { UsersUserId = 5, PlatformsPlatformId = 1 },
                new { UsersUserId = 6, PlatformsPlatformId = 3 },
                new { UsersUserId = 7, PlatformsPlatformId = 3 },
                new { UsersUserId = 8, PlatformsPlatformId = 3 },
                new { UsersUserId = 9, PlatformsPlatformId = 3 },
                new { UsersUserId = 10, PlatformsPlatformId = 3 },
                new { UsersUserId = 10, PlatformsPlatformId = 2 },
                new { UsersUserId = 11, PlatformsPlatformId = 3 })
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
              new Nationality() { NationalityId = 1, Name = "Sweden" },
              new Nationality() { NationalityId = 2, Name = "Norway" },
              new Nationality() { NationalityId = 3, Name = "Denmark" },
              new Nationality() { NationalityId = 4, Name = "Germany" },
              new Nationality() { NationalityId = 5, Name = "Great Britain" },
              new Nationality() { NationalityId = 6, Name = "Spain" },
              new Nationality() { NationalityId = 7, Name = "France" },
              new Nationality() { NationalityId = 8, Name = "USA" }
              );

            //Personalitie
            modelBuilder.Entity<Personality>().HasData(
              new Personality() { PersonalityId = 1, Description = "Cute" },
              new Personality() { PersonalityId = 2, Description = "Narcissistic" },
              new Personality() { PersonalityId = 3, Description = "Manipulative" },
              new Personality() { PersonalityId = 4, Description = "Shy" },
              new Personality() { PersonalityId = 5, Description = "Leader" },
              new Personality() { PersonalityId = 6, Description = "Strategist" }

              );

            //Platform
            modelBuilder.Entity<Platform>().HasData(
              new Platform() { PlatformId = 1, Name = "XBOX" },
              new Platform() { PlatformId = 2, Name = "PS" },
              new Platform() { PlatformId = 3, Name = "PC" }
              );

            //Friend
            modelBuilder.Entity<Friend>().HasData(
                new Friend() { FriendId = 1, SenderId = 1, ReceiverId = 2, CategoryId = 1, StatusId = 1 },
                new Friend() { FriendId = 2, SenderId = 2, ReceiverId = 3, CategoryId = 2, StatusId = 2 },
                new Friend() { FriendId = 3, SenderId = 3, ReceiverId = 1, CategoryId = 1, StatusId = 2 }
            );

            //Post
            modelBuilder.Entity<Post>().HasData(
               new Post() { PostId = 1, ReceiverId = 1, SenderId = 2, Content = "Holy shit dude.", TimeStamp = DateTime.Now },
               new Post() { PostId = 2, ReceiverId = 2, SenderId = 3, Content = "Holy shit dude.", TimeStamp = DateTime.Now },
               new Post() { PostId = 3, ReceiverId = 3, SenderId = 1, Content = "Holy shit dude.", TimeStamp = DateTime.Now }
               );

            //Status
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
                new User() { UserId = 1, NationalityId = 1, PersonalityId = 1,NickName="Pandrum", FirstName = "Simon", LastName = "Bernsdorff Wallstedt", Mail = "simon.bernsdorff-wallstedt@dating.com", Age = 28, Online = false, Gender = "Male", Active = true, ImgUrl = "~/img/avatars/csgo1.jpg" },
                new User() { UserId = 2, NationalityId = 1, PersonalityId = 2,NickName="brollestar", FirstName = "Lukas", LastName = "Brolin", Mail = "lukas.brolin@dating.com", Age = 27, Online = false, Gender = "Male", Active = true, ImgUrl = "~/img/avatars/csgo2.jpg" },
                new User() { UserId = 3, NationalityId = 1, PersonalityId = 3,NickName="paraplydricka", FirstName = "Filip", LastName = "Johansson", Mail = "filip.johansson@dating.com", Age = 27, Online = false, Gender = "Male", Active = true, ImgUrl = "~/img/avatars/csgo3.jpg" },
                new User() { UserId = 4, NationalityId = 1, PersonalityId = 4,NickName="magge", FirstName = "Magnus", LastName = "Fredriksson", Mail = "magnus.fredriksson@dating.com", Age = 34, Online = false, Gender = "Male", Active = true, ImgUrl = "~/img/avatars/csgo4.jpg" },
                new User() { UserId = 5, NationalityId = 2, PersonalityId = 2,NickName="didhje", FirstName = "Didrik", LastName = "Hjelm", Mail = "didrik.hjelm@dating.com", Age = 22, Online = false, Gender = "Male", Active = true, ImgUrl = "~/img/avatars/dota1.jpg" },
                new User() { UserId = 6, NationalityId = 2, PersonalityId = 5,NickName="Selma", FirstName = "Selma", LastName = "Nordheim", Mail = "selma.nordheim@dating.com", Age = 25, Online = false, Gender = "Female", Active = true, ImgUrl = "~/img/avatars/dota2.jpg" },
                new User() { UserId = 7, NationalityId = 1, PersonalityId = 1,NickName="Kassi", FirstName = "Kassandra", LastName = "Lökholm", Mail = "kassandra.Lökholm@dating.com", Age = 27, Online = false, Gender = "Female", Active = true, ImgUrl = "~/img/avatars/pubg.jpg" },
                new User() { UserId = 8, NationalityId = 1, PersonalityId = 5,NickName="Kentaflenta", FirstName = "Kent", LastName = "Andersson", Mail = "kent.andersson@dating.com", Age = 31, Online = false, Gender = "Male", Active = true, ImgUrl = "~/img/avatars/wow1.jpg" },
                new User() { UserId = 9, NationalityId = 4, PersonalityId = 3,NickName="Vettelmano", FirstName = "Sebastian", LastName = "Vettel", Mail = "sebastian.vettel@dating.com", Age = 41, Online = false, Gender = "Male", Active = true, ImgUrl = "~/img/avatars/wow2.jpg" },
                new User() { UserId = 10, NationalityId = 4, PersonalityId = 3,NickName="Spyking", FirstName = "Nico", LastName = "Rosberg", Mail = "nico.rosberg@dating.com", Age = 38, Online = false, Gender = "Male", Active = true, ImgUrl = "~/img/avatars/wow3.jpg" },
                new User() { UserId = 11, NationalityId = 5, PersonalityId = 4,NickName="Hermione", FirstName = "Emma", LastName = "Watson", Mail = "emma.watson@dating.com", Age = 30, Online = false, Gender = "Female", Active = true, ImgUrl = "~/img/avatars/wow.6.jpg" });
        }
    }
}