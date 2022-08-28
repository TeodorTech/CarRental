
using CarRental.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
   public class BookingRepository: IBookingRepository
    {
        private List<Booking> ListOfBookings = new List<Booking>();

        public void CreateTheBook(Booking book)
        {
            ListOfBookings.Add(book);
        }
        public Booking GetById(int id)
        {
            return ListOfBookings.FirstOrDefault(b => b.BookingId == id);
        }
        public IEnumerable<Booking> GetAll()
        {
            return ListOfBookings;
        }
        public void Delete(Booking booking)
        {
            ListOfBookings.Remove(ListOfBookings.FirstOrDefault(b => b.BookingId == id));
        }


    }
}
