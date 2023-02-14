using MyLibraryApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MyLibraryApp.Data
{
    public class LibraryDbContext : DbContext
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options, IPasswordHasher<User> passwordHasher) : base(options)
        {
            _passwordHasher = passwordHasher;
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
            new LibraryInitializer(modelBuilder, _passwordHasher).Seed();
        }
    }
}
