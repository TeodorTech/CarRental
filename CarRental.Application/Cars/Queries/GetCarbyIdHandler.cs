using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Queries
{
    public class GetCarbyIdHandler : IRequestHandler<GetCarById, Car>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCarbyIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Car> Handle(GetCarById request, CancellationToken cancellationToken)
        {
            var car = _unitOfWork._carRepo.GetCarById(request.CarId);
            return Task.FromResult(car);
        }
    }
}
