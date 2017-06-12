using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelTravel
{
    class TravelAgency
    {
        private static readonly string CC_Num = "4987949494944909";
        private Boolean roomsNeeded = true;
        private double unitPrice;
        private string hotelId;
        private static Boolean hotelAvailable = true;

        public static bool HotelAvailable
        {
            get
            {
                return hotelAvailable;
            }

            set
            {
                hotelAvailable = value;
            }
        }

        public void Run()
        {
            if (hotelAvailable)
            {
                if (roomsNeeded)
                    createOrder(hotelId);
                else
                {
                    Console.WriteLine("Room Not Needed");
                    Thread.Sleep(2000);
                    roomsNeeded = true;
                }
            }
            
        }
        public void createOrder(string hotelId) {
           
            Console.WriteLine("Creating Order" + Thread.CurrentThread.Name);
            roomsNeeded = false;
            Order order = new Order();
            order.Amount = 10;
            order.CC_Num = CC_Num;
            order.SenderId = Thread.CurrentThread.Name;
            order.RecieverId = hotelId;
            Program.mbuff.addElement(Encoder.EncodeOrder(order));
        }

        public void SubscribeEvent(HotelSupplier hotelsup)
        {
            Console.WriteLine("Subscribing to Price Cut Event...");
            hotelsup.PriceCut += Hotelsup_PriceCut;
        }

        private void Hotelsup_PriceCut(PCutEventArgs pr)
        {
            Console.WriteLine("Subscribe: " + pr.Id);
            unitPrice = pr.Price;
            hotelId = pr.Id;
        }


    }
}
