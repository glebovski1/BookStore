using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.DataAccess.AppContext
{
    public class TestAppContext : IdentityDbContext<User, IdentityRole<int>, int>
    {

        public TestAppContext(DbContextOptions<TestAppContext> options) : base(options)
        {
        }


        public DbSet<Author> Aurhors { get; set; }

        public DbSet<AuthorInBook> AuthorInBooks { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItems> OrderItems { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PrintingEdition> PrintingEditions { get; set; }

        public DbSet<Role> Role { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
