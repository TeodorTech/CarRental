using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces.Repositories
{
   public interface IBookingRepository
    {

        public Task CreateTheBook(Booking book);
        public void Delete(Booking booking);
        public Booking GetBookingById(int id);
        public List<Booking> GetAll();



    }
}
