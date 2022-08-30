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
        }

        public  void Delete(Car car)
        {
           _context.Cars.Remove(car);
        }
        public void  Update(Car car)
        {
             _context.Cars.Update(car);
        }

        public Car GetCarById(int id)
        {
           var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            return car;
        }
        public List<Car> GetAll()
        {
            return _context.Cars.ToList();
        }
        public List<Car> GetAllCarsByMake(string make)
        {
            var filteredList = _context.Cars.Where(c => c.Make == make).ToList();
            return filteredList;
        }
        public List<Car> GetAllCarsByPrice(int price)
        {
            var filteredList = _context.Cars.Where(c=>c.PricePerDay>=price).ToList();
            return filteredList;
        }
    }
}
