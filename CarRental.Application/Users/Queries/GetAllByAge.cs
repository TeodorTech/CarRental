using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Queries
{
    public class GetAllByAge:IRequest<List<User>>
    {
        public int Age { get; set; }
    }
}
