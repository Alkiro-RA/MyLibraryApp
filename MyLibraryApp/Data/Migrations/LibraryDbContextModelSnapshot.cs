﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLibraryApp.Data;

#nullable disable

namespace MyLibraryApp.Data.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyLibraryApp.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Fiodor Dostojewski",
                            MemberId = 1,
                            Title = "Zbrodnia i kara"
                        },
                        new
                        {
                            Id = 2,
                            Author = "J.R.R. Tolkien",
                            MemberId = 1,
                            Title = "Hobbit"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Jarosław Grzędowicz",
                            MemberId = 1,
                            Title = "Pan lodowego ogrodu"
                        },
                        new
                        {
                            Id = 4,
                            Author = "J.R.R. Tolkien",
                            MemberId = 1,
                            Title = "Hobbit"
                        });
                });

            modelBuilder.Entity("MyLibraryApp.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Library"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Member"
                        });
                });

            modelBuilder.Entity("MyLibraryApp.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "library@mylibrary.com",
                            Password = "AQAAAAEAACcQAAAAEGTjLU8NM99z1T+RIJeToFiuO4yP5X0q9Ge7EjZL67tOycv/DdYdeujrkXAEISp5qA==",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "admin@mylibrary.com",
                            Name = "Adam",
                            Password = "AQAAAAEAACcQAAAAEEgamGUkMvfEvqACrRi+VTBhNNw1/MnnlZdCxod426CGoh+gDL7gUmmo0V76fz96Nw==",
                            RoleId = 2,
                            Surname = "Nowak"
                        },
                        new
                        {
                            Id = 3,
                            Email = "member@mylibrary.com",
                            Name = "Jan",
                            Password = "AQAAAAEAACcQAAAAEPSARBQNVLxKDrrt9V4spV3B3/RkUejmHFgXjJ5UtwVSN9LvRTBNa29W9J2mRfr7pw==",
                            RoleId = 3,
                            Surname = "Kowalski"
                        });
                });

            modelBuilder.Entity("MyLibraryApp.Model.Book", b =>
                {
                    b.HasOne("MyLibraryApp.Model.User", "Member")
                        .WithMany("Books")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MyLibraryApp.Model.User", b =>
                {
                    b.HasOne("MyLibraryApp.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MyLibraryApp.Model.User", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
