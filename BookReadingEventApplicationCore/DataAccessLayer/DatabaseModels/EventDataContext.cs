using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DatabaseModels
{
    public class EventDataContext : DbContext
    {
        

        public EventDataContext(DbContextOptions<EventDataContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Event { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventDataConfiguration());
            modelBuilder.ApplyConfiguration(new CommentDataConfiguration());
            modelBuilder.ApplyConfiguration(new UserDataConfiguration());


        }
    }
}
