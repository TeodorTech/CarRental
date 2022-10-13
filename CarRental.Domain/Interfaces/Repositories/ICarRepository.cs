using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Repositories
{
    public interface ICarRepository
    {

        public Task CreateCar(Car car);
       
        public void Delete(Car car);
        public  Task Update(Car car);
        public  Car GetCarById(int id);
        public List<Car> GetAll();
        public List<Car> GetAllCarsByMake(string make);
        public List<Car> GetAllCarsByPrice(int price);
        public List<Car> CarFilter(string? make,string? color, int? price);

    }
}
