using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    interface IUser
    {
        public string CheckAge(int age);
        public Car SelectCar();
        public void PayCar(Car car);
    }
}
