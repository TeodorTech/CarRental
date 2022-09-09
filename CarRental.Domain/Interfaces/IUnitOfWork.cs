using CarRental.Application.Repositories;
using CarRental.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICarRepository _carRepo { get; }
        public IUserRepository _userRepo { get; }
        public IBookingRepository _bookRepo { get;  }

        Task Save();
        
    }
}
