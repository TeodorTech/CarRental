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
    public class DeleteCarHandler : IRequestHandler<DeleteCar, Car>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCarHandler(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<Car> Handle(DeleteCar request, CancellationToken cancellationToken)
        {
            var car = _unitOfWork._carRepo.GetCarById(request.CarId);
            if (car == null) return null;
             _unitOfWork._carRepo.Delete(car);
            await _unitOfWork.Save();
            return car;
        }
    }
}
