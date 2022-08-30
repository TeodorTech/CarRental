using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Queries
{
    public class GetUsersByCityHandler : IRequestHandler<GetUsersByCity, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUsersByCityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<User>> Handle(GetUsersByCity request, CancellationToken cancellationToken)
        {
            var cityList = _unitOfWork._userRepo.GetByCity(request.City);
            return Task.FromResult(cityList);
        }
    }
}
