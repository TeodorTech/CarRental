using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces.Repositories
{
   public interface IBookingRepository
    {

        public void CreateTheBook(Booking book);
        public Booking GetById(int id);
        public IEnumerable<Booking> GetAll();
        public void Delete(Booking booking);

     

    }
}
