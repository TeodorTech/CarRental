using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Cars.Queries
{
    public class GetCarById:IRequest<Car>
    {
        public int CarId { get; set; }
    }
}
