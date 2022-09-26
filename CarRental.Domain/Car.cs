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
        public string Color { get; set; }
        public int Year { get; set; }
        public float PricePerDay { get; set; }
        public string ImageLink { get; set; }
        public ICollection<Booking> Booking { get; set; }
        public Car()
        {

        }

        public Car(string make, string model,string color, int year, float pricePerDay,string imageLink)
        {

            this.Make = make;
            this.Model = model;
            this.Color = color;
            this.Year = year;
            this.PricePerDay = pricePerDay;
            this.ImageLink = imageLink;


        }




    }
}