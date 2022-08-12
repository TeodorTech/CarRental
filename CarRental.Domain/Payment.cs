using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Interfaces;

namespace CarRental.Domain
{
    public class Payment : IPayment
    {

        public int pricePerDay;
        public bool isPaid;
        public string type;
        public string status;
        public double numberDaysRented;
        public string carmake;
        public static List<Payment> listOfPayments = new List<Payment>();

        public override string ToString() => $"{carmake},{type},{status}";




        public Payment(string carmake, string type)
        {

            this.type = type;
            this.carmake = carmake;
            listOfPayments.Add(this);

        }
        ///Here i have overloaded the method <summary>
        /// Here i have overloaded the method
        /// </summary>
        /// <param name="numberDaysRented"></param>
        /// <returns></returns>
        public int Total(int numberDaysRented) { return pricePerDay * numberDaysRented; }
        public double Total(double numberDaysRented) { return pricePerDay * numberDaysRented; }
        public float Total(float numberDaysRented) { return pricePerDay * numberDaysRented; }

        public void GetType()
        {
            if (this.type == "Card")
                Console.WriteLine("Redirect to payment page");
            else if (this.type == "Cash")
                Console.WriteLine("You need to pay extra");
            else
            {
                Console.WriteLine("We do not accept crypto");
            }

        }

        public void GetStatus()
        {
            if (this.status == "Accepted")
                Console.WriteLine("Your car is booked!!!!");
            else if (this.status == "Pending")
                Console.WriteLine("Loading...");
            else
            {
                Console.WriteLine("Payment failed! TRY AGAIN!");
            }

        }

    }
    }
