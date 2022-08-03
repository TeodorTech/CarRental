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
        public string model;
        public int year;
        private bool available;
        public bool Available { get => available; set => available = value; }
        public float price;
        public override string ToString() => $"{make},{price}";

        public Car(string make, string model, int year, float price)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.price = price;
            this.available = true;
            id = Guid.NewGuid();
        }
        
        public static List<Car>GenerateListOfCars(Car[] car)
        {

            var ListOfCars = new List<Car>();
            ListOfCars.AddRange(car);
            return ListOfCars;
           
                    
    }



        
    }
}
