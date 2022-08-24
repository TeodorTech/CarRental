
using CarRental.Application;
using CarRental.Application.Bookings.Command;
using CarRental.Application.Cars.Commands;
using CarRental.Application.Commands;
using CarRental.Application.Queries;
using CarRental.Application.Repositories;
using CarRental.Application.Users.Commands;
using CarRental.Application.Users.Queries;
using CarRental.Domain;
using CarRental.Domain.Exceptions;
using CarRental.Domain.Interfaces.Repositories;
using CarRental.Infrastrcuture;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace CarRental.Program
{
    public class Programe
    {

        static async Task Main(string[] args)
        {
           


            User userTeodor = new User("", "Nicolau", 23);
            User userAlex = new User("Alex", "Dinca", 26);
            User userGabi = new User("Gabi", "Stan", 24);
            User userIoana = new User("Ioana", "Dinca", 23);
            try
            {
                userAlex.CheckAge(userAlex.Age);

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

            var diContainer = new ServiceCollection()
                .AddScoped<ICarRepository, CarRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IBookingRepository, BookingRepository>()
                .AddMediatR(typeof(CreateCarHandler))
                .BuildServiceProvider();
            var mediator = diContainer.GetRequiredService<IMediator>();
            /* var newcar = await mediator.Send(new CreateCar
             {   Id=10,
                 Make = "Paganni",
                 Price = 1000
             });
             var newListOfCars = await mediator.Send(new GetAllCars{ });*/
            var user1 = await mediator.Send(new CreateUser
            {
                FirstName = "Johhny",
                LastName = "Bravo",
                Age = 28
            });
            var user2 = await mediator.Send(new CreateUser
            {
                FirstName = "Johhny",
                LastName = "Cash",
                Age = 20
            });
            var user3 = await mediator.Send(new CreateUser
            {
                FirstName = "Miki",
                LastName = "Mouse",
                Age = 30
            });

            var newListOfUsers = await mediator.Send(new GetAllUsers { });

            var newBooking = await mediator.Send(new CreateBooking
            {
                userId = 1,
                carId=2
            });
            Console.WriteLine();
            




            /*  Car selctedCarAlex = userAlex.SelectCar();
              userAlex.PayCar(selctedCarAlex);

              Car selectedCarTeodor = userTeodor.SelectCar();
              userTeodor.PayCar(selectedCarTeodor);

              Car selectedCarGabi = userGabi.SelectCar();
              userGabi.PayCar(selectedCarGabi);*/



            /*   int count = 1;
               foreach (Payment payment in Payment.listOfPayments)
               {
                   Console.WriteLine($"Payment number {count} is {payment}");
                   count++;
               }
               foreach (User user in User.listOfUsers)
               {
                   Console.WriteLine($"Logged users are {user.firstName}");
               }
   */





            /*UserRepository userRepository = new UserRepository();*/




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


            /*  
             
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