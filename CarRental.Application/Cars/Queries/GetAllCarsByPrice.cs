using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Queries
{
    public class GetAllCarsByPrice:IRequest<List<Car>>
    {
        public int Price { get; set; }
    }
}
