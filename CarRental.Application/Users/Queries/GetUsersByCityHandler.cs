using CarRental.Application.Repositories;
using CarRental.Domain;
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
        private readonly IUserRepository _userRepo;
        public GetUsersByCityHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<List<User>> Handle(GetUsersByCity request, CancellationToken cancellationToken)
        {
            var cityList = _userRepo.GetByCity(request.City);
            return Task.FromResult(cityList);
        }
    }
}
