
using CarRental.Domain.Interfaces.Repositories;
using CarRental.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
   public class BookingRepository: IBookingRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<BookingRepository> _logger;
        public BookingRepository(DataContext context, ILogger<BookingRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateTheBook(Booking book)
        {
            await _context.Bookings.AddAsync(book);
            
        }
        public void Delete(Booking booking)
        {
            _context.Bookings.Remove(booking);
        }
      
        public Booking GetBookingById(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == id);
            _logger.LogInformation($"The booking with ID {id} was retrived");
            return booking;
        }
        public List<Booking> GetAll()
        {
            _logger.LogInformation($"The list of bookings has been retrived");
            return _context.Bookings.ToList();

        }
        public List<Booking> GetBookingByUserId(int userId)
        {
            return _context.Bookings.Where(b => b.UserId == userId).ToList();
        }
       


    }
}
