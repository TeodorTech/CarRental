﻿using CarRental.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure
{
    public class DataContext : DbContext
    {

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Booking> Bookings{ get; set; }
     /*   protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Booking>()
                .HasKey(b => new { b.CarId, b.UserId });
            builder.Entity<Booking>()
                .HasOne(b => b.Car)
                .WithMany(b => b.Booking)
                .HasForeignKey(b => b.CarId);
            builder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(b => b.Booking)
                .HasForeignKey(b => b.UserId);
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlServer(@"Data Source=DESKTOP-JEIF0LB\SQLEXPRESS; Initial Catalog=CarRentalDB; Trusted_Connection=True;");
    }
}