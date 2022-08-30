using CarRental.Application.Queries;
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
    public class GetAllCarsHandler : IRequestHandler<GetAllCars, List<Car>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCarsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    public Task<List<Car>> Handle(GetAllCars request, CancellationToken cancellationToken)
    {
            var listOfCars = _unitOfWork._carRepo.GetAll();
            return Task.FromResult(listOfCars);
    }
}
}
