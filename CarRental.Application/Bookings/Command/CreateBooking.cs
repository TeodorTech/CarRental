using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Bookings.Command
{
    public class CreateBooking : IRequest<Booking>
    {
        public int carId { get; set; }
        public int userId { get; set; }
    }
}
