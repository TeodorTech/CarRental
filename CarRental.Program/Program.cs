
using CarRental.Domain;
using CarRental.Domain.Exceptions;
using System.Diagnostics;


namespace CarRental.Program
{
    public class Programe
    {
        
        static void Main(string[] args)
        {


            User userTeodor = new User("", "Nicolau", 23);
            User userAlex = new User("Alex", "Dinca", -5);
            try
            {
                userAlex.CheckAge();

            }
            catch (ExceptionAge ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception er)
            {
                Debug.WriteLine(er.Message);
                Console.WriteLine(er.Message);
            }

#if RELEASE
            finally
            {
                Debug.WriteLine("We are in Debug");
                Console.WriteLine("The programe was executed in DEBUG");
            }
#endif



            Payment payHonda = new Payment(100, true,"Card", "Accepted");
            Payment payToyota = new Payment(150, false,"Crypto","Denied");


            Car carHonda = new Car("Honda", "Civic", 2020, 25000);
            Car carToyota = new Car("Toyota", "Supra", 2021, 30500);
            Car carAudi = new Car("Audi", "R8", 2007, 40000);
            Car carMercedes = new Car("Mercedes", "S-class", 2016, 42000);
            Car carBmw = new Car("BMW", "M4", 2018, 54000);
            Car carPorche = new Car("Porche", "911 Carrera", 2021, 140000);

            Booking bookHonda = new Booking(payHonda.Total(0), payHonda.isPaid, carHonda, userTeodor);
            Booking bookToyota = new Booking(payToyota.Total(10), payToyota.isPaid, carToyota, userAlex);

            /*  ///Here we take the make of the Car object and write them in a txt file
              WriteReadText file = new WriteReadText();
              file.WriteTheNames(new string[] { carHonda.make, carToyota.make, carAudi.make,carBmw.make,carMercedes.make,carPorche.make });

              ///Here i read from that txt file and then I create a new txt file with each car having an index.
              int count = 1;
              string[]array = new string[10];
              foreach (string car in File.ReadAllLines(@"D:\CarRentalProject\CarRental\Folder\ListOfCars.txt"))
              {
                  array[count]=($"{car} is the car at the index {count++}");

              }
              File.WriteAllLines(@"D:\CarRentalProject\CarRental\Folder\ListOfCarIndexes.txt", array);*/

            payHonda.GetStatus();
            payHonda.GetType();
            var vehicle = VehicleFactory.GenerateVehicle(userTeodor.age);
            vehicle.CheckVehicle();
            var vehicle2 = VehicleFactory.GenerateVehicle(userAlex.age);
            vehicle2.CheckVehicle();

            var payment = PaymentSingleton.ExecutePayment();
            var payment2 = PaymentSingleton.ExecutePayment();
            var payment3 = PaymentSingleton.ExecutePayment();
        }





    }
}