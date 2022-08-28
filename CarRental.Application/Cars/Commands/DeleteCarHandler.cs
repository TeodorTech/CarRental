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
    public class DeleteCarHandler : IRequestHandler<DeleteCar, Car>
    {
        private readonly ICarRepository _carRepo;
        public DeleteCarHandler(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        public Task<Car> Handle(DeleteCar request, CancellationToken cancellationToken)
        {
            var car = _carRepo.GetById(request.CarId);
            if (car == null) return null;
            _carRepo.Delete(car);
            return Task.FromResult(car);
        }
    }
}
