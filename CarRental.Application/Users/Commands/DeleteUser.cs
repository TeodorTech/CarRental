using CarRental.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Commands
{
    public class DeleteUser:IRequest<User>
    {
        public int UserId { get; set; }
    }
}
