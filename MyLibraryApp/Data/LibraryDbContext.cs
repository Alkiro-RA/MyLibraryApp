﻿using MyLibraryApp.Model;
using Microsoft.EntityFrameworkCore;

namespace MyLibraryApp.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            new LibraryInitializer(modelBuilder).Seed();
        }
    }
}