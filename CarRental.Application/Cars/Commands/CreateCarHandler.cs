using CarRental.Application.Commands;
using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Commands
{
    public class CreateCarHandler : IRequestHandler<CreateCar, Car>
    {
        private readonly ICarRepository _carRepo;
        public CreateCarHandler(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        public async Task<Car> Handle(CreateCar request, CancellationToken cancellationToken)
        {
            var car = new Car(request.Make,request.Model, request.Year, request.PricePerDay);
            await _carRepo.CreateCar(car);
           
            return car;
        }
    }
}
