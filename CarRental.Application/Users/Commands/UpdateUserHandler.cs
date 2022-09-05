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
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var userToUpdate = new User
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                City = request.City,
                Email = request.Email,

            };
             await _unitOfWork._userRepo.UpdateUser(userToUpdate);
            await _unitOfWork.Save();
            return userToUpdate;
        }
    }
}
