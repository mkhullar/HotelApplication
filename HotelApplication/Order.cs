using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravel
{
    public class Order
    {
        private string senderId;
        private string recieverId;
        private string cC_Num;
        private double amount;

        public string SenderId
        {
            get
            {
                return senderId;
            }

            set
            {
                senderId = value;
            }
        }

        public string RecieverId
        {
            get
            {
                return recieverId;
            }

            set
            {
                recieverId = value;
            }
        }

        public string CC_Num
        {
            get
            {
                return cC_Num;
            }

            set
            {
                cC_Num = value;
            }
        }

        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }
    }
}
