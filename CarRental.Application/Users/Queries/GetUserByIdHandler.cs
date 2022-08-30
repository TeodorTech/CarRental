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
    public class GetUserByIdHandler : IRequestHandler<GetUserById, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork._userRepo.GetById(request.UserId);
            return Task.FromResult(user);
        }
    }
}
