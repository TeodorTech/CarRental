using CarRental.Domain;

namespace SingletonApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var payment = PaymentSingleton.ExecutePayment();
            var payment2 = PaymentSingleton.ExecutePayment();
            var payment3 = PaymentSingleton.ExecutePayment();
        }
         /*   for (int i = 1; i < 20; i++)
            {
                server1.SendRequest($"{i}");
            }
            for (int i = 1; i < 20; i++)
            {
                server2.SendRequest($"{i}");
            }*/
            /* int[] ListOfAges = { 13, 14, 45, 23, 17, 20 };
             foreach(int age in ListOfAges)
             {
                 var vehicle = VehicleFactory.GenerateVehicle(age);
                 vehicle.Speed();
             }



         }

         public static class VehicleFactory
         {

             public static IVehicle GenerateVehicle(int age)
             {
                 if (age >= 18)
                 {
                     return new Car();

                 }
                 return new Bike();
             }
         }
         public class Car : IVehicle
         {
             public void Speed()
             {
                 Console.WriteLine("I go fast");
             }
         }
         public class Motorbike : IVehicle
         {
             public void Speed()
             {
                 Console.WriteLine("I go dangerous");
             }
         }
         public class Bike : IVehicle
         {
             public void Speed()
             {
                 Console.WriteLine("I go slow");
             }
         }
         public interface IVehicle
         {
             void Speed();
         }
 */
        }
}