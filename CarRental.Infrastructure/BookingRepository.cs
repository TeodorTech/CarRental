
using CarRental.Domain.Interfaces.Repositories;
using CarRental.Infrastructure;
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
        public BookingRepository(DataContext context)
        {
            _context = context;
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
            return booking;
        }
        public List<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }
       


    }
}
