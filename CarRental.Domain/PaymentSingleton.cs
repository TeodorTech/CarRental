using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class PaymentSingleton
    {
        private static PaymentSingleton intent = null;
        private PaymentSingleton()
        {
            Console.WriteLine("Payment is loading");
        }
        public static PaymentSingleton ExecutePayment()
        {
            if (intent == null)
            {
                intent = new PaymentSingleton();
                return intent;
            }
            else
            {
                Console.WriteLine("This car is not available for the moment");
                return intent;
            }
        }
    }
}


