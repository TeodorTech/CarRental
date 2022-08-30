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
    public class GetAllCarsByMakeHandler : IRequestHandler<GetAllCarsByMake, List<Car>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCarsByMakeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Car>> Handle(GetAllCarsByMake request, CancellationToken cancellationToken)
        {
            var filteredList = _unitOfWork._carRepo.GetAllCarsByMake(request.Make);
            return Task.FromResult(filteredList);
        }
    }
}
