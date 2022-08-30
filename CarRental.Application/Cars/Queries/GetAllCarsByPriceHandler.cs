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
    public class GetAllCarsByPriceHandler : IRequestHandler<GetAllCarsByPrice, List<Car>>
    {
        private readonly ICarRepository _carRepo;
        public GetAllCarsByPriceHandler(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        public Task<List<Car>> Handle(GetAllCarsByPrice request, CancellationToken cancellationToken)
        {
            var filtredList = _carRepo.GetAllCarsByPrice(request.Price);
            return Task.FromResult(filtredList);
        }
    }
}
