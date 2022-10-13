using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Infrastructure;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CarRepository> _logger;
        public CarRepository(DataContext context, ILogger<CarRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        public async Task CreateCar(Car car)
        {
            await _context.Cars.AddAsync(car);
        }

        public void Delete(Car car)
        {
            _context.Cars.Remove(car);

        }
        public async Task Update(Car car)
        {
            _context.Cars.Update(car);
        }

        public Car GetCarById(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            _logger.LogInformation($"The car with ID {id} was retrived");
            return car;
        }
        public List<Car> GetAll()
        {
            _logger.LogInformation($"The list of cars has been retrived");
            return _context.Cars.ToList();

        }
        public List<Car> GetAllCarsByMake(string make)
        {
            var filteredList = _context.Cars.Where(c => c.Make == make).ToList();
            _logger.LogInformation($"List of {make} was retrived");
            return filteredList;
        }
        public List<Car> GetAllCarsByPrice(int price)
        {
            var filteredList = _context.Cars.Where(c => c.PricePerDay >= price).ToList();
            _logger.LogInformation($"List of cars higher than {price} was retrived");
            return filteredList;
        }

        public List<Car> CarFilter(string? make, string? color, int? price)
        {
            var selectedCars = _context.Cars;
            if (make != null && color != null && price!=null)
            {
                return selectedCars.Where(c => c.Make == make && c.Color == color && c.PricePerDay==price).ToList();
            }
            if (make != null && color != null)
            {
                return selectedCars.Where(c => c.Make == make && c.Color == color).ToList();
            }
            if (price != null && color != null)
            {
                return selectedCars.Where(c => c.PricePerDay == price && c.Color == color).ToList();
            }
            if (make != null)
            {
              return  selectedCars.Where(c => c.Make == make).ToList();
            }
            if (color != null)
            {
               return selectedCars.Where(c => c.Color == color).ToList();
            }
            if (price != null)
            {
                 return selectedCars.Where(c => c.PricePerDay == price).ToList();
            }
          

            return selectedCars.ToList();
        }
    }
}
