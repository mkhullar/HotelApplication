using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravel
{
    class PCutEventArgs : EventArgs
    {
        private string id;
        private double price;

        public PCutEventArgs(string id, double price)
        {
            this.id = id;
            this.price = price;
        }

        public string Id
        {
            get
            {return id;}

            set
            {
                id = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}
