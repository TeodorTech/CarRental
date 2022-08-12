using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class Booking
    {
        private Guid id;
        public Guid Id { get => id; }

        public int total;
        public bool isBooked;
        public Car car;
        public User user;

        public Booking(int total, bool isBooked, Car car, User user)
        {
            id = Guid.NewGuid();
            this.total = total;
            this.isBooked = isBooked;
            this.car = car;

        }
        public void BookCar()
        {
            try
            {
                if (car == null)
                {
                    throw new  Exceptions.InvalidBookingException("You need to select a car");
                }
                else
                {
                    car.available = !isBooked;
                    if (car.available)
                    {
                        Console.WriteLine("Car is available");
                    }
                    else
                    {
                        Console.WriteLine("Car is NOT available!!!");
                    }
                }
               
            }
            catch (Exceptions.InvalidBookingException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        /* catch (Exceptions.InvalidBookingException ex)
         {
             Console.WriteLine(ex.Message);
         }*/
    }
}

