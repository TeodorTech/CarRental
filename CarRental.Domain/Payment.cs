using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class Payment
    {
        private int id;
        public int Id { get => id; set => id = value; }
        public int pricePerDay;
        public bool isPaid;
        public double numberDaysRented;

        public Payment(int pricePerDay, bool isPaid)
        {

            this.pricePerDay = pricePerDay;
            this.isPaid = isPaid;


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
