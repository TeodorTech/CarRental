using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarRental.Domain
{
    public class Payment 
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
      

  

 

    }
    }
