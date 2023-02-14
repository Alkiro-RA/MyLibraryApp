using MyLibraryApp.Data;
using MyLibraryApp.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Identity;

namespace MyLibraryApp.Data
{
    public class LibraryInitializer
    {
        private readonly ModelBuilder _modelBuilder;
        private readonly IPasswordHasher<User> _passwordHasher;
        public LibraryInitializer(ModelBuilder modelBuilder, IPasswordHasher<User> passwordHasher)
        {
            _modelBuilder = modelBuilder;
            _passwordHasher = passwordHasher;
        }
        public void Seed()
        {
            SeedRoles();
            SeedUsers();
            SeedBooks();
        }

        private void SeedRoles()
        {
            _modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Name = "Library"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Admin"
                },
                new Role()
                {
                    Id = 3,
                    Name = "Member"
                });
        }

        private void SeedUsers()
        {
            _modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Email = "library@mylibrary.com",
                    Password = Hash("library"),
                    RoleId = 1 // library
                },
                new User()
                {
                    Id = 2,
                    Name = "Adam",
                    Surname = "Nowak",
                    Email = "admin@mylibrary.com",
                    Password = Hash("admin"),
                    RoleId = 2 // admin
                },
                new User()
                {
                    Id = 3,
                    Name = "Jan",
                    Surname = "Kowalski",
                    Email = "member@mylibrary.com",
                    Password = Hash("member"),
                    RoleId = 3 // member
                });
        }

        private void SeedBooks()
        {
            _modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Title = "Zbrodnia i kara",
                    Author = "Fiodor Dostojewski",
                    MemberId = 1
                },
                new Book()
                {
                    Id = 2,
                    Title = "Hobbit",
                    Author = "J.R.R. Tolkien",
                    MemberId = 1
                },
                new Book()
                {
                    Id = 3,
                    Title = "Pan lodowego ogrodu",
                    Author = "Jarosław Grzędowicz",
                    MemberId = 1
                },
                new Book()
                {
                    Id = 4,
                    Title = "Hobbit",
                    Author = "J.R.R. Tolkien",
                    MemberId = 1
                });
        }

        private string Hash(string password)
        {
            string hashedPassword = string.Empty;
            hashedPassword = _passwordHasher.HashPassword(new User(), password);
            return hashedPassword;
        }
    }
}
