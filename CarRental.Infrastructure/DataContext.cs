using CarRental.Domain;
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
        public DataContext(){}
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Teodor", LastName = "Nicolau", Age = 23, Email = "teo.steaua07@yahoo.com", City = "Bucuresti" },
                new User { Id = 2, FirstName = "Ioana", LastName = "Dinca", Age = 24, Email = "ioana.dinca@yahoo.com", City = "Constanta" },
                new User { Id = 3, FirstName = "Alex", LastName = "Dinca", Age = 24, Email = "alex.dinca@yahoo.com", City = "Constanta" },
                new User { Id = 4, FirstName = "Andrei", LastName = "Ion", Age =21, Email = "andrei.ion@yahoo.com", City = "Cluj" },
                new User { Id = 5, FirstName = "George", LastName = "Enescu", Age = 45, Email = "=george.enescu@yahoo.com", City = "Timisoara" },
                new User { Id = 6, FirstName = "Cristiano", LastName = "Ronaldo", Age = 38, Email = "cristiano.ronaldo@yahoo.com", City = "Constanta" },
                new User { Id = 7, FirstName = "Leonardo", LastName = "Davinci", Age = 99, Email = "leonardo.davinci@yahoo.com", City = "Suceava" },
                new User { Id = 8, FirstName = "Brad", LastName = "Pitt", Age =49, Email = "brad.pitt@yahoo.com", City = "Timisoara" },
                new User { Id = 9, FirstName = "Megan", LastName = "Fox", Age = 45, Email = "megan.fox@yahoo.com", City = "Bucuresti" },
                new User { Id = 10, FirstName = "barack", LastName = "Obama", Age = 50, Email = "barak.obama@yahoo.com", City = "Constanta" },
                new User { Id = 11, FirstName = "Steph", LastName = "Curry", Age = 30, Email = "steph.curry@yahoo.com", City = "Cluj" },
                new User { Id = 12, FirstName = "James", LastName = "LeBron", Age = 35, Email = "lebron.james@yahoo.com", City = "Constanta" }

            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlServer(@"Data Source=DESKTOP-JEIF0LB\SQLEXPRESS; Initial Catalog=CarRentalDB; Trusted_Connection=True;");
    }
}
