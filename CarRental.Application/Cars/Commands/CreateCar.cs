using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Commands
{
    public class CreateCar:IRequest<Car>
    {
        public int Id { get; set; } 
        public string Make { get; set; } = null!;
        public float Price { get; set; } 
    }
}
