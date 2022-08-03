using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class User
    {
        public string firstName;
        public string lastName;
        private Guid id;
        public int age;

        public Guid Id { get => id; }
        public User(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.age = age;
            id = Guid.NewGuid();
            this.lastName = lastName;
            try
            {
                if (firstName == string.Empty ||lastName==string.Empty)
                {
                    throw new Exceptions.InvalidUserException("Enter your First name");
                }
                else
                {
                    Console.WriteLine($"You entered succesfully your name {firstName} {lastName}");
                }
            }
            catch (Exceptions.InvalidUserException ex)
            {
           
                Console.WriteLine(ex.Message);
             

            }

        }
        public void CheckAge()
        {
            try
            {
                if (age > 18)
                {
                    Console.WriteLine("You can drive <3");
                }
                else if (age < 18 && age > 0)
                {
                    throw new Exceptions.ExceptionAge("!!!Rent a bike!!!");
                }
                else
                {
                    throw new Exception("!!!Try again, age was incorect!!!");
                }
            }
            catch
            {
                throw;

            }
        }

    }

}
