using CarRental.Domain;
using CarRental.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Bookings.Queries
{
    public class GetBookingByIdHandler : IRequestHandler<GetBookingById, Booking>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBookingByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Booking> Handle(GetBookingById request, CancellationToken cancellationToken)
        {
            var booking = _unitOfWork._bookRepo.GetBookingById(request.Id);
            return Task.FromResult(booking);
        }
    }
}
