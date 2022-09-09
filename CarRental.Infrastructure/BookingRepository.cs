
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
  /*      public Booking GetById(int id)
        {
            return ListOfBookings.FirstOrDefault(b => b.BookingId == id);
        }
        public IEnumerable<Booking> GetAll()
        {
            return ListOfBookings;
        }
        public void Delete(Booking booking)
        {
            ListOfBookings.Remove(ListOfBookings.FirstOrDefault(b => b.BookingId == booking.BookingId));
        }*/


    }
}
