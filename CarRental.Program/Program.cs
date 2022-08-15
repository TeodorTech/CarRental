
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
            User userAlex = new User("Alex", "Dinca",26);
            User userGabi = new User("Gabi", "Stan", 24);
            User userIoana = new User("Ioana", "Dinca", 23);
            try
            {
                userAlex.CheckAge(userAlex.age);

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

            Car selctedCarAlex = userAlex.SelectCar();
            userAlex.PayCar(selctedCarAlex);

            Car selectedCarTeodor = userTeodor.SelectCar();
            userTeodor.PayCar(selectedCarTeodor);

            Car selectedCarGabi = userGabi.SelectCar();
            userGabi.PayCar(selectedCarGabi);

            

            int count = 1;
            foreach (Payment payment in Payment.listOfPayments)
            {
                Console.WriteLine($"Payment number {count} is {payment}");
                count++;
            }
            foreach (User user in User.listOfUsers)
            {
                Console.WriteLine($"Logged users are {user.firstName}");
            }

          

            

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

            ///Test new payment methods
            /*  payHonda.GetStatus();
              payHonda.GetType();

              ///Test Vehicle factory
              var vehicle = VehicleFactory.GenerateVehicle(userTeodor.age);
              vehicle.CheckVehicle();
              var vehicle2 = VehicleFactory.GenerateVehicle(userAlex.age);
              vehicle2.CheckVehicle();
              ///Test the singleton
              var payment = PaymentSingleton.ExecutePayment();
              var payment2 = PaymentSingleton.ExecutePayment();
              var payment3 = PaymentSingleton.ExecutePayment();

              BookingV2 bookPorche = new BookingV2(carPorche.make, payPorche.status, userTeodor.firstName);
              Console.WriteLine(bookPorche);*/
            /*bookPorche.BookCar();
            bookHonda.BookCar();
*/

        }





    }
}