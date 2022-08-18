using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class Car
    {
        private Guid id;
        public Guid Id { get => id; }
        public string make;
        public int year;
        public bool available;
        public float price;
        public override string ToString() => $"{make},{available}";

        public static List<Car> GenerateListOfCars()
        {
            return new List<Car>
            {
                new Car { make = "Honda", price = 15000 },
                new Car { make = "Mazda", price = 25000 },
                new Car { make = "Dacia", price = 1000 },
                new Car { make = "Audi", price = 40000 },
                new Car { make = "Porche", price = 50000 },
                new Car { make = "Mercedes", price = 100500 },
                new Car { make = "BMW", price = 50500 },

            };
        }
      
    }
}