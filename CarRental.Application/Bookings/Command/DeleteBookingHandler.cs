using CarRental.Domain;
using CarRental.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBookingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Booking> Handle(DeleteBooking request, CancellationToken cancellationToken)
        {
            var booking = _unitOfWork._bookRepo.GetBookingById(request.Id);
            if (booking == null) return null;
            _unitOfWork._bookRepo.Delete(booking);
            await _unitOfWork.Save();
            return booking;
        }
    }
}
