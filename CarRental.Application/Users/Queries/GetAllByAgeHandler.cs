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
    public class GetAllByAgeHandler : IRequestHandler<GetAllByAge, List<User>>
    {
        private readonly IUserRepository _userRepo;
        public GetAllByAgeHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<List<User>> Handle(GetAllByAge request, CancellationToken cancellationToken)
        {
            var filtredList = _userRepo.GetByAge(request.Age);
            return Task.FromResult(filtredList);
        }
    }
}
