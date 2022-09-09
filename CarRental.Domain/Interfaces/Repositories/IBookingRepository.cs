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
       /* public Booking GetById(int id);
        public IEnumerable<Booking> GetAll();
        public void Delete(Booking booking);*/

     

    }
}
