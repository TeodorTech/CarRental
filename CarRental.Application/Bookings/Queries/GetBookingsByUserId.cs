using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Bookings.Queries
{
    public class GetBookingsByUserId:IRequest<List<Booking>>
    {
        public int UserId { get; set; }
    }
}
