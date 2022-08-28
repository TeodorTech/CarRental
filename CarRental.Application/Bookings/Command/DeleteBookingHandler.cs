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
    public class DeleteBookingHandler : IRequestHandler<DeleteBooking, Booking>
    {
        private readonly IBookingRepository _bookingRepo;
        public DeleteBookingHandler(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public Task<Booking> Handle(DeleteBooking request, CancellationToken cancellationToken)
        {
            var booking = _bookingRepo.GetById(request.Id);
            if (booking == null) return null;
            _bookingRepo.Delete(booking);
            return Task.FromResult(booking);
        }
    }
}
