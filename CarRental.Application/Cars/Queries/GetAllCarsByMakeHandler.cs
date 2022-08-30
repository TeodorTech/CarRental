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
    public class GetAllCarsByMakeHandler : IRequestHandler<GetAllCarsByMake, List<Car>>
    {
        private readonly ICarRepository _carRepo;
        public GetAllCarsByMakeHandler(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        public Task<List<Car>> Handle(GetAllCarsByMake request, CancellationToken cancellationToken)
        {
            var filteredList = _carRepo.GetAllCarsByMake(request.Make);
            return Task.FromResult(filteredList);
        }
    }
}
