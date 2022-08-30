using CarRental.Application.Repositories;
using CarRental.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DataContext _context;
        public ICarRepository _carRepo { get; private set; }
        public IUserRepository _userRepo { get; private set; }
        public UnitOfWork(DataContext context,ICarRepository carRepo,IUserRepository userRepo)
        {
            _carRepo = carRepo;
            _userRepo = userRepo;
            _context = context;
        }
       public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
