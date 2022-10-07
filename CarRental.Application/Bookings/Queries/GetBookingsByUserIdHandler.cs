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
    public class GetBookingsByUserIdHandler : IRequestHandler<GetBookingsByUserId, List<Booking>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBookingsByUserIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<List<Booking>> Handle(GetBookingsByUserId request, CancellationToken cancellationToken)
        {
            var filteredList = _unitOfWork._bookRepo.GetBookingByUserId(request.UserId);
            return Task.FromResult(filteredList);
        }
    }
}
