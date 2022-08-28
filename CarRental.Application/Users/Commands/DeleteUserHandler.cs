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
    public class DeleteUserHandler : IRequestHandler<DeleteUser, User>
    {
        private readonly IUserRepository _userRepo;
        public DeleteUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<User> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var user = _userRepo.GetById(request.Id);
            if (user == null) return null;
            _userRepo.Delete(user);
            return Task.FromResult(user);
        }

    }
}
