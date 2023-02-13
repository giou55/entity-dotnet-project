using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity_dotnet_project.Models;
using Microsoft.EntityFrameworkCore;

namespace entity_dotnet_project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        // creates a table in database called "Users"
        public DbSet<User> Users { get; set; } 

        // creates a table in database called "Likes",
        // it is going to be used as a join table to relate our entities
        // so that we have got our many to many relationship,
        // it'll be a table with two columns,
        // one the SourceUserId with integers
        // and two the TargetUserId also with integers
        public DbSet<Like> Likes { get; set; }

        // creates a table in database called "Messages",
        // it is going to be used as a join table to relate our entities
        // so that we have got our many to many relationship,
        public DbSet<Message> Messages { get; set; }

        // we override this method that's inside the DbContext class
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            // we use this method from base DbContext class, 
            // even if in most cases it ins't necessary
            base.OnModelCreating(builder);

            // we add configuration for Likes table
            builder.Entity<Like>()
                // we specify the primary key for Likes table, that is made up of two entities
                .HasKey(k => new {k.SourceUserId, k.TargetUserId});

            builder.Entity<Like>()
                // we configure a relationship
                // and we say that a SourceUser can likes many LikedUsers
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                // if a user deletes his profile, it also will be deleted the corresponding likes
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Like>()
                // we configure a relationship
                // and we say that a TargetUser can be liked many LikedByUsers
                .HasOne(s => s.TargetUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.TargetUserId)
                // if a user deletes his profile, it also will be deleted the corresponding likes
                .OnDelete(DeleteBehavior.Cascade);

            // if we're using SQL server, we have to change one of these:
            // OnDelete(DeleteBehavior.Cascade)
            // with this:
            // OnDelete(DeleteBehavior.NoAction)
            // otherwise we'll get an error

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                // if a sender user deletes his profile, we want the recipient of the message 
                // should still be able to see that message
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                // if a sender user deletes his profile, we want the recipient of the message 
                // should still be able to see that message
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}