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

        public async Task<Car> Handle(UpdateCar request, CancellationToken cancellationToken)
        {
            var carToUpdate = new Car
            {
                Id = request.Id,
                Make=request.Make,
                Model = request.Model,
                Year = request.Year,
                PricePerDay = request.PricePerDay,
                ImageLink = request.ImageLink
            };
            await _unitOfWork._carRepo.Update(carToUpdate);
            await _unitOfWork.Save();
            return carToUpdate;
        }
    }
}
