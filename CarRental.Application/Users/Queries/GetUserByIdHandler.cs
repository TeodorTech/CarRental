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
    public class GetUserByIdHandler : IRequestHandler<GetUserById, User>
    {
        private readonly IUserRepository _userRepo;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        public Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = _userRepo.GetById(request.UserId);
            return Task.FromResult(user);
        }
    }
}
