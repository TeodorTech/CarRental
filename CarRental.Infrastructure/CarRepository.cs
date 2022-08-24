using CarRental.Application.Repositories;
using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastrcuture
{
    public class CarRepository : ICarRepository
    {
        private List<Car> _cars = new List<Car>

            {
                new Car {  Id = 1,Make = "Honda", Price = 15000 },
                new Car {  Id = 2,Make = "Mazda", Price = 25000 },
                new Car { Id = 3, Make = "Dacia", Price = 1000 },
                new Car { Id = 4, Make = "Audi", Price = 40000 },
                new Car { Id = 5, Make = "Porche", Price = 50000 },
                new Car { Id = 6, Make = "Mercedes", Price = 100500 },
                new Car { Id = 7, Make = "BMW", Price = 50500 },

            };

        public void CreateCar(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(string make)
        {
            var car = _cars.FirstOrDefault(c => c.Make == make);
            _cars.Remove(car);
        }

        public void Update(Car car)
        {
            var toUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            toUpdate.SetUpdate(car);

        }

        public Car GetById(int id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
    }
}
