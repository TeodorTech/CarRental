using CarRental.Application.Commands;
using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        public CreateCarHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Car> Handle(CreateCar request, CancellationToken cancellationToken)
        {
            var car = new Car(request.Make,request.Model,request.Color, request.Year, request.PricePerDay,request.ImageLink);
            await _unitOfWork._carRepo.CreateCar(car);
            await _unitOfWork.Save();
            return car;
        }
    }
}
