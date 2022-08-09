using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Interfaces;

namespace CarRental.Domain
{
    public static class VehicleFactory
    {

        public static IVehicle GenerateVehicle(int age)
        {
            if (age >= 18)
            {
                return new Auto();

            }
            return new Bike();
        }
}
    public class Auto : IVehicle
    {
        public void CheckVehicle()
        {
            Console.WriteLine("You can drive  a CAR!!!");
        }
    }
    public class Motorbike : IVehicle
    {
        public void CheckVehicle()
        {
            Console.WriteLine("You can drive a MOTO");
        }
    }
    public class Bike : IVehicle
    {
        public void CheckVehicle()
        {
            Console.WriteLine("You can not drive a CAR, but you can rent a bike!");
        }
    }
   
 
}
