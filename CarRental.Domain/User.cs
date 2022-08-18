using CarRental.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class User:IUser
    {
        public string firstName;
        public string lastName;
        public int age;
        public string email;
        private Guid id;
        public Guid Id { get => id; }
        public Car car;
        public Payment payment;
        public static List<User> listOfUsers = new List<User>();
        public override string ToString() => $"{firstName},{lastName},{age}";

        public User()
        {
        }

        public User(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.age = age;
            id = Guid.NewGuid();
            this.lastName = lastName;
            listOfUsers.Add(this);
            try
            {
                CheckName(firstName, lastName);
            }
            catch
            {
                Console.WriteLine("You failed to enter your name");
            }
            

        }


        public string CheckAge(int age)
        {
            try
            {
                if (age > 18 && age < 65)
                {
                    return "You can drive <3";
                }
                else if (age < 18 && age > 0)
                {
                    throw new Exceptions.ExceptionAge("!!!Rent a bike!!!");
                }
                else if (age > 65)
                {
                    throw new Exceptions.ExceptionAge("You are too old to drive");
                }
                else
                {
                    throw new Exceptions.ExceptionAge("!!!Try again, age was incorect!!!");
                }
            }
            catch
            {
                throw;
            }
        }

        public Car SelectCar()
        {
            Console.WriteLine("What car do you want to rent?");
            string make = Console.ReadLine();
            var listOfCars = Car.GenerateListOfCars();
            
            foreach (Car car in listOfCars)
            
            {
                if (car.make == make)
                {
                    /*car.available = false;*/
                    return car;
                }
            }
            return car;
        }

        public void PayCar(Car car)
        {
            Console.WriteLine("How do you want to pay?");
            string paymentType = Console.ReadLine();
            payment = new Payment(car.make, paymentType);
            payment.status = "Paid";
            car.available = false;
            Console.WriteLine("Your car is paid");

        }

        public void CheckName(string firstName, string lastName)
        {
            try
            {
                if (firstName == string.Empty || lastName == string.Empty)
                {
                    throw new Exceptions.InvalidUserException("You failed to enter your name");

                }
                else
                {
                    Console.WriteLine($"You entered succesfully your name {firstName} {lastName}");
                }
            }
            catch (Exceptions.InvalidUserException ex)
            {

                throw;
            }
        }
        }
}

