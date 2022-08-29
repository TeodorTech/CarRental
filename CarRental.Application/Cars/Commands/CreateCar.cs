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
      
        public string Make { get; set; } 
        public string Model { get; set; } 
        public int Year { get; set; }
        public float PricePerDay { get; set; } 
    }
}
