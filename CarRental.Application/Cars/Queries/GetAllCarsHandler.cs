using CarRental.Application.Queries;
using CarRental.Application.Repositories;
using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Queries
{
    public class GetAllCarsHandler : IRequestHandler<GetAllCars, List<Car>>
    {
        private readonly ICarRepository _carRepo;
        public GetAllCarsHandler(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

    public Task<List<Car>> Handle(GetAllCars request, CancellationToken cancellationToken)
    {
            var listOfCars = _carRepo.GetAll();
            return Task.FromResult(listOfCars);

    }
}
}
