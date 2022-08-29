using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class Car
    {

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public float PricePerDay { get; set; }
        public ICollection<Booking> Booking { get; set; }
        public Car()
        {

        }

        public Car( string make, string model, int year, float pricePerDay)
        {
           
            this.Year = year;
            this.Make = make;
            this.Model = model;
            this.PricePerDay = pricePerDay;

        }

        public void SetUpdate(Car car)
        {
            Make = car.Make;
            PricePerDay = car.PricePerDay;
        }




    }
}