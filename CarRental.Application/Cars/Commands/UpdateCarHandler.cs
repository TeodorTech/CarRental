using CarRental.Application.Repositories;
using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Commands
{
    public class UpdateCarHandler : IRequestHandler<UpdateCar, Car>
    {
        private readonly ICarRepository _carRepo;
        public UpdateCarHandler(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        public Task<Car> Handle(UpdateCar request, CancellationToken cancellationToken)
        {
            var carToUpdate = new Car
            {
                Id = request.Id,
                Make=request.Make,
                Model = request.Model,
                PricePerDay = request.PricePerDay,
            };
            _carRepo.Update(carToUpdate);
            return Task.FromResult(carToUpdate);
        }
    }
}
