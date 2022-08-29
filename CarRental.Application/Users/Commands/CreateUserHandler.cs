using CarRental.Application.Repositories;
using CarRental.Domain;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Commands
{
   public class CreateUserHandler:IRequestHandler<CreateUser,User>
    {
        private readonly IUserRepository _userRepo;
        public CreateUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new User(request.FirstName, request.LastName, request.Age,request.Email);
            await _userRepo.CreateUser(user);
            return user;

        }
    }
}
