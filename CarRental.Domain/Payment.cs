using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class Payment : IPayment
    {
        private int id;
        public int Id { get => id; set => id = value; }
        public int pricePerDay;
        public bool isPaid;
        private readonly string type;
        private readonly string status;
        public double numberDaysRented;

        public Payment(int pricePerDay, bool isPaid,string type, string status)
        {
            
            this.pricePerDay = pricePerDay;
            this.isPaid = isPaid;
            this.type = type;
            this.status = status;
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
        public static List<string> GenerateListOfPayments(string[] status)
        {

            var ListOfPayments = new List<string>();
            ListOfPayments.AddRange(status);
            return ListOfPayments;

        }



        }
    }
