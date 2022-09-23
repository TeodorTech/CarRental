﻿// <auto-generated />
using System;
using CarRental.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220923055707_ImageLink")]
    partial class ImageLink
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRental.Domain.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            BookingId = 1,
                            CarId = 1,
                            EndDate = new DateTime(2022, 9, 23, 8, 57, 6, 685, DateTimeKind.Local).AddTicks(4212),
                            StartDate = new DateTime(2022, 9, 23, 8, 57, 6, 685, DateTimeKind.Local).AddTicks(4181),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("CarRental.Domain.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PricePerDay")
                        .HasColumnType("real");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageLink = "https://thumbs.dreamstime.com/b/tula-russia-march-porsche-turbo-s-white-sports-car-coupe-isolated-white-background-d-rendering-tula-russia-march-porsche-turbo-225956942.jpg",
                            Make = "Porche",
                            Model = "911",
                            PricePerDay = 350f,
                            Year = 2008
                        },
                        new
                        {
                            Id = 2,
                            ImageLink = "https://thumbs.dreamstime.com/b/tula-russia-march-porsche-turbo-s-white-sports-car-coupe-isolated-white-background-d-rendering-tula-russia-march-porsche-turbo-225956942.jpg",
                            Make = "Porche",
                            Model = "Cayene",
                            PricePerDay = 500f,
                            Year = 2020
                        },
                        new
                        {
                            Id = 3,
                            ImageLink = "https://thumbs.dreamstime.com/b/tula-russia-march-porsche-turbo-s-white-sports-car-coupe-isolated-white-background-d-rendering-tula-russia-march-porsche-turbo-225956942.jpg",
                            Make = "Porche",
                            Model = "Panamera",
                            PricePerDay = 450f,
                            Year = 2016
                        },
                        new
                        {
                            Id = 4,
                            ImageLink = "https://thumbs.dreamstime.com/b/tula-russia-march-porsche-turbo-s-white-sports-car-coupe-isolated-white-background-d-rendering-tula-russia-march-porsche-turbo-225956942.jpg",
                            Make = "Porche",
                            Model = "918",
                            PricePerDay = 1050f,
                            Year = 2021
                        });
                });

            modelBuilder.Entity("CarRental.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 23,
                            City = "Bucuresti",
                            Email = "teo.steaua07@yahoo.com",
                            FirstName = "Teodor",
                            LastName = "Nicolau"
                        },
                        new
                        {
                            Id = 2,
                            Age = 24,
                            City = "Constanta",
                            Email = "ioana.dinca@yahoo.com",
                            FirstName = "Ioana",
                            LastName = "Dinca"
                        },
                        new
                        {
                            Id = 3,
                            Age = 24,
                            City = "Constanta",
                            Email = "alex.dinca@yahoo.com",
                            FirstName = "Alex",
                            LastName = "Dinca"
                        },
                        new
                        {
                            Id = 4,
                            Age = 21,
                            City = "Cluj",
                            Email = "andrei.ion@yahoo.com",
                            FirstName = "Andrei",
                            LastName = "Ion"
                        },
                        new
                        {
                            Id = 5,
                            Age = 45,
                            City = "Timisoara",
                            Email = "=george.enescu@yahoo.com",
                            FirstName = "George",
                            LastName = "Enescu"
                        },
                        new
                        {
                            Id = 6,
                            Age = 38,
                            City = "Constanta",
                            Email = "cristiano.ronaldo@yahoo.com",
                            FirstName = "Cristiano",
                            LastName = "Ronaldo"
                        },
                        new
                        {
                            Id = 7,
                            Age = 99,
                            City = "Suceava",
                            Email = "leonardo.davinci@yahoo.com",
                            FirstName = "Leonardo",
                            LastName = "Davinci"
                        },
                        new
                        {
                            Id = 8,
                            Age = 49,
                            City = "Timisoara",
                            Email = "brad.pitt@yahoo.com",
                            FirstName = "Brad",
                            LastName = "Pitt"
                        },
                        new
                        {
                            Id = 9,
                            Age = 45,
                            City = "Bucuresti",
                            Email = "megan.fox@yahoo.com",
                            FirstName = "Megan",
                            LastName = "Fox"
                        },
                        new
                        {
                            Id = 10,
                            Age = 50,
                            City = "Constanta",
                            Email = "barak.obama@yahoo.com",
                            FirstName = "Barack",
                            LastName = "Obama"
                        },
                        new
                        {
                            Id = 11,
                            Age = 30,
                            City = "Cluj",
                            Email = "steph.curry@yahoo.com",
                            FirstName = "Steph",
                            LastName = "Curry"
                        },
                        new
                        {
                            Id = 12,
                            Age = 35,
                            City = "Constanta",
                            Email = "lebron.james@yahoo.com",
                            FirstName = "James",
                            LastName = "LeBron"
                        },
                        new
                        {
                            Id = 13,
                            Age = 35,
                            City = "Constanta",
                            Email = "lebron.james@yahoo.com",
                            FirstName = "James",
                            LastName = "LeBron"
                        });
                });

            modelBuilder.Entity("CarRental.Domain.Booking", b =>
                {
                    b.HasOne("CarRental.Domain.Car", "Car")
                        .WithMany("Booking")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Domain.User", "User")
                        .WithMany("Booking")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRental.Domain.Car", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("CarRental.Domain.User", b =>
                {
                    b.Navigation("Booking");
                });
#pragma warning restore 612, 618
        }
    }
}
