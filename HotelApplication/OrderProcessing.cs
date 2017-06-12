using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace HotelTravel
{
    class OrderProcessing
    {
        private const double tax = 0.8;
        private const double locCharge = 70;
        private const string CC_Reg = "^4[0-9]{12}(?:[0-9]{3})?$"; //Visa card

        private Order order;
        private double unitPrice;

        public Order Order

        {

            get { return order; }

            private set { order = value; }

        }

        public double UnitPrice

        {

            get { return unitPrice; }

            set { unitPrice = value; }

        }


        public OrderProcessing(Order order, double unitPrice)
        {
            this.order = order;
            this.unitPrice = unitPrice;
        }

        public void ProcessOrder()
        {
            if (order== null)
            {
                Console.WriteLine("Bad Order");
            }
            else
            {
                if (Regex.IsMatch(order.CC_Num, CC_Reg))
                {
                    Console.WriteLine("Card Validated" + Thread.CurrentThread.Name);
                    Console.WriteLine("Order Processed " + ((order.Amount * unitPrice)/tax + locCharge).ToString("C"));
                }
                else
                {
                    Console.WriteLine("Card Invalid" + Thread.CurrentThread.Name);
                }
            }
        }
    }
}
