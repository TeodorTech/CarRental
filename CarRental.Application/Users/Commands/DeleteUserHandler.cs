using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<User> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork._userRepo.GetById(request.UserId);
            if (user == null) return null;
            _unitOfWork._userRepo.Delete(user);
            return Task.FromResult(user);
        }

    }
}
