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
    public class CarSelectorHandler : IRequestHandler<CarSelector, List<Car>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarSelectorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<List<Car>> Handle(CarSelector request, CancellationToken cancellationToken)
        {
            var selectedCars = _unitOfWork._carRepo.CarFilter(request.Make,request.Color, request.Price);
            return Task.FromResult(selectedCars);
        }
    }
}
