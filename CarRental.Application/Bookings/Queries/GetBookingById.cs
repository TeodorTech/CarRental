using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Bookings.Queries
{
    public class GetBookingById:IRequest<Booking>
    {
        public int Id { get; set; }
    }
}
