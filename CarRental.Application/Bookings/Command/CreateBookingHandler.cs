using CarRental.Domain;
using CarRental.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Bookings.Command
{
    public class CreateBookingHandler : IRequestHandler<CreateBooking, Booking>
    {
        private IBookingRepository _bookingRepo;
        public CreateBookingHandler(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public Task<Booking> Handle(CreateBooking request, CancellationToken cancellationToken)
        {
            var booking = new Booking(request.carId, request.userId);
            _bookingRepo.CreateTheBook(booking);
            return Task.FromResult(booking);
            
        }
    }
}
