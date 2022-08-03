using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Exceptions
{
    public class ExceptionAge : Exception
    {
        public ExceptionAge(string? message) : base(message)
        {
        }

    }
}
