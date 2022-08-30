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
    public class GetCarbyIdHandler : IRequestHandler<GetCarById, Car>
    {
        private readonly ICarRepository _carRepo;
       public GetCarbyIdHandler(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        public Task<Car> Handle(GetCarById request, CancellationToken cancellationToken)
        {
            var car = _carRepo.GetCarById(request.CarId);
            return Task.FromResult(car);
        }
    }
}
