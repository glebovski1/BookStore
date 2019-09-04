using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.AppContext
{
    public class TestAppContext : DbContext
    {

        public TestAppContext(DbContextOptions<TestAppContext> options) : base(options)
        {

            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Author> Aurhors { get; set; }

        public DbSet<AuthorInBook> AuthorInBooks { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItems> OrderItems { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PrintingEdition> PrintingEditions { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserInRole> UserInRoles { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User[]
            {
                new User { Id=1, FirstName="Tom"},
                new User { Id=2, FirstName="Alice"},
                new User { Id=3, FirstName="Sam"}
            });
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
