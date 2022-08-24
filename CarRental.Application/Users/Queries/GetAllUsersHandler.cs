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
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, List<User>>
    {
        private readonly IUserRepository _userRepo;
        public GetAllUsersHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<List<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var listOfUsers = _userRepo.GetAll();
            return Task.FromResult(listOfUsers);
        }
    }
}
