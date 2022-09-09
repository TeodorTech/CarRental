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
    public class CreateBookingHandler : IRequestHandler<CreateBooking, Booking>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Booking> Handle(CreateBooking request, CancellationToken cancellationToken)
        {
            var booking = new Booking(request.CarId, request.UserId,request.StartDate,request.EndDate);
            await _unitOfWork._bookRepo.CreateTheBook(booking);
            await _unitOfWork.Save();
            return booking;
            
        }
    }
}
