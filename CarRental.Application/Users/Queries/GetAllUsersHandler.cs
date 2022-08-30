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
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllUsersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var listOfUsers = _unitOfWork._userRepo.GetAll();
            return Task.FromResult(listOfUsers);
        }
    }
}
