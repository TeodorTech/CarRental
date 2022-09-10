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
    public class GetAllBookingsHandler : IRequestHandler<GetAllBookings, List<Booking>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllBookingsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<List<Booking>> Handle(GetAllBookings request, CancellationToken cancellationToken)
        {
            var listOfBookings = _unitOfWork._bookRepo.GetAll();
            return Task.FromResult(listOfBookings);
        }
    }
}
