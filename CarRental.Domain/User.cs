
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class User : IdentityUser<int>
    { 

       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        /*public string Email { get; set; }*/
        public string City { get; set; }
        public ICollection<Booking> Booking { get; set; }

        public override string ToString() => $"{FirstName},{LastName},{Age}";
        public User()
        {

        }
    

        public User(string FirstName, string LastName, int Age,string City,string Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.City = City;
            this.Email = Email;
            try
            {
                CheckName(FirstName, LastName);
            }
            catch
            {
                Console.WriteLine("You failed to enter your name");
            }
        }


        public string CheckAge(int Age)
        {
            try
            {
                if (Age > 18 && Age < 65)
                {
                    return "You can drive <3";
                }
                else if (Age < 18 && Age > 0)
                {
                    throw new Exceptions.ExceptionAge("!!!Rent a bike!!!");
                }
                else if (Age > 65)
                {
                    throw new Exceptions.ExceptionAge("You are too old to drive");
                }
                else
                {
                    throw new Exceptions.ExceptionAge("!!!Try again, Age was incorect!!!");
                }
            }
            catch
            {
                throw;
            }
        }



        public void SetUserUpdate(User user)
        {
            Age = user.Age;
            Email = user.Email;
        }
        public void CheckName(string Firstname, string LastName)
        {
            try
            {
                if (Firstname == string.Empty || LastName == string.Empty)
                {
                    throw new Exceptions.InvalidUserException("You failed to enter your name");

                }
                else
                {
                    Console.WriteLine($"You entered succesfully your name {Firstname} {LastName}");

                }
            }
            catch (Exceptions.InvalidUserException ex)
            {

                throw;
            }
        }
    }
}

