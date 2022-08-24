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
        public int Year { get; set; }
        public bool Available { get; set; }
        public float Price { get; set; }
        public ICollection<Booking> Booking { get; set; }
        public override string ToString() => $"{Make},{Available}";
        public Car()
        {

        }


        public Car(int id, string make, float  price)
        {
            this.Id = id;
            this.Make = make;
            this.Price = price;

        }

        public void SetUpdate(Car car)
        {
            Make = car.Make;
            Price = car.Price;
        }




    }
}