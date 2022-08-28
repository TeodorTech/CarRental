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

        public void CreateCar(Car car);
       
        public void Delete(Car car);
        public  Car GetById(int id);
        public List<Car> GetAll();
        public void Update(Car car);

    }
}
