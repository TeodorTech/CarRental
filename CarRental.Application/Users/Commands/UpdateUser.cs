using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users
{
    public class UpdateUser:IRequest<User>
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        
    }
}
