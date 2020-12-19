﻿using System;
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
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Personality> Personalities { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<FriendList> FriendLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<FriendList>().HasKey(x => x.FriendListID);

            
            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<FriendList>().ToTable("FriendLists");
        }
    }
}