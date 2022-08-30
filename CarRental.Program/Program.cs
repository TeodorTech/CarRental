
using CarRental.Application;
using CarRental.Application.Bookings.Command;
using CarRental.Application.Cars.Commands;
using CarRental.Application.Cars.Queries;
using CarRental.Application.Commands;
using CarRental.Application.Queries;
using CarRental.Application.Repositories;
using CarRental.Application.Users;
using CarRental.Application.Users.Commands;
using CarRental.Application.Users.Queries;
using CarRental.Domain;
using CarRental.Domain.Exceptions;
using CarRental.Domain.Interfaces.Repositories;
using CarRental.Infrastrcuture;
using CarRental.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace CarRental.Program
{
    public class Programe
    {

        static async Task Main(string[] args)
        {
           

#if RELEASE
            finally
            {
                Debug.WriteLine("We are in Debug");
                Console.WriteLine("The programe was executed in DEBUG");
            }
#endif

            var diContainer = new ServiceCollection()
                .AddScoped<ICarRepository, CarRepository>()
                .AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-JEIF0LB\SQLEXPRESS; Initial Catalog=CarRentalDB; Trusted_Connection=True;"))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IBookingRepository, BookingRepository>()
                .AddMediatR(typeof(CreateCarHandler))
                .BuildServiceProvider();
            var mediator = diContainer.GetRequiredService<IMediator>();
            /*   var newcar = await mediator.Send(new CreateCar
               {

                   Make = "Dacia",
                   Model = "Logan",
                   Year = 2005,
                   PricePerDay = 100
               });*/
            /*await mediator.Send(new DeleteCar { CarId = 1 });*/
            /*await mediator.Send(new UpdateCar { Id = 1,Make="Dacia",Model="Logan",PricePerDay=1 });*/
            /*    var newUser = await mediator.Send(new CreateUser
                {
                    FirstName = "Alex",
                    LastName = "Dinca",
                    Age = 26,
                    Email = "alex.dinca@yahoo.com"
                });*/
            /*await mediator.Send(new DeleteUser { UserId = 1 });*/
            var allCars = mediator.Send(new GetAllCars { });
            var filteredList = mediator.Send(new GetAllCarsByMake { Make="BMW"});
            var expensivecars = mediator.Send(new GetAllCarsByPrice { Price = 400 });
            var selectedcar = mediator.Send(new GetCarById { CarId = 4 });
            
         /*   foreach(Car car in allCars)
            {
                var newcar = car;
            }
           */
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