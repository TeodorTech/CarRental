using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastrcuture
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;
        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateCar(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }


        public  void Delete(Car car)
        {
           _context.Cars.Remove(car);
            _context.SaveChanges();
             
        }

        public void  Update(Car car)
        {
             _context.Cars.Update(car);
             _context.SaveChanges();
        }

        public Car GetById(int id)
        {
           var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            return car;
        }

        public List<Car> GetAll()
        {
            return _context.Cars.ToList();
        }
    }
}
