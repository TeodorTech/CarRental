using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public override string ToString() => $"The car with id {CarId} is book by the user with{UserId}";

        public Booking( int carId, int userId)
        {
            CarId = carId;
            UserId = userId;
        }
    }
}

