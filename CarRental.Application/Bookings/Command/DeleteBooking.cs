using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Bookings.Command
{
    public class DeleteBooking:IRequest<Booking>
    {
        public int Id { get; set; }

    }
}
