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
    public class GetAllByAgeHandler : IRequestHandler<GetAllByAge, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllByAgeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<User>> Handle(GetAllByAge request, CancellationToken cancellationToken)
        {
            var filtredList = _unitOfWork._userRepo.GetByAge(request.Age);
            return Task.FromResult(filtredList);
        }
    }
}
