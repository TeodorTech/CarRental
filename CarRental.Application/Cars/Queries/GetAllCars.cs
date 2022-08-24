using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Queries
{
    public class GetAllCars:IRequest<List<Car>>
    {
     
    }
}
