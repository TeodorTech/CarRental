using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCarHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            _unitOfWork._carRepo.Update(carToUpdate);
            return Task.FromResult(carToUpdate);
        }
    }
}
