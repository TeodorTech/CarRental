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
    public class GetAllCarsByPriceHandler : IRequestHandler<GetAllCarsByPrice, List<Car>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCarsByPriceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Car>> Handle(GetAllCarsByPrice request, CancellationToken cancellationToken)
        {
            var filtredList = _unitOfWork._carRepo.GetAllCarsByPrice(request.Price);
            return Task.FromResult(filtredList);
        }
    }
}
