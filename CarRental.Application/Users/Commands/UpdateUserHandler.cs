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
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly IUserRepository _userRepo;
        public UpdateUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var userToUpdate = new User
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Email = request.Email,

            };
            _userRepo.UpdateUser(userToUpdate);
            return Task.FromResult(userToUpdate);
        }
    }
}
