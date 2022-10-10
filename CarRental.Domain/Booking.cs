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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
       
        public int UserId { get; set; }
      
        public User User { get; set; }
        public string CarMake { get; set; }
        public string TotalCost { get; set; }


        public Booking()
        {

        }

        public Booking(int carId, int userId,DateTime startDate, DateTime endDate, string carMake, string totalCost)
        {
            CarId = carId;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            CarMake = carMake;
            TotalCost = totalCost;
        }
    }
}

