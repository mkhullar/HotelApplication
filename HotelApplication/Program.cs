using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HotelTravel
{
    class Program
    {
        public static MultiCellBuffer mbuff = new MultiCellBuffer();
        public static Thread[] hotelTh = new Thread[2];
        public static Thread[] travelTh = new Thread[5];
        public static HotelSupplier[] hotelSup = new HotelSupplier[2];
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {   HotelSupplier hotelSupplier = new HotelSupplier();
                hotelSup[i] = hotelSupplier;
                hotelTh[i] = new Thread(hotelSupplier.Run);
                hotelTh[i].Name = "hotelSupplier_" + i;
                hotelTh[i].Start();
                while (!hotelTh[i].IsAlive) ;
            }

            for (int i = 0; i < 5; i++){

                TravelAgency travelAgency = new TravelAgency();
                for (int j = 0; j < 2; j++)
                {
                    travelAgency.SubscribeEvent(hotelSup[j]);
                }
                travelTh[i] = new Thread(travelAgency.Run);
                travelTh[i].Name = "travelAgency_" + i;
                travelTh[i].Start();
                Console.WriteLine("HotelAlive1");
                while (!travelTh[i].IsAlive) ;
                Console.WriteLine("HotelAlive2");
            }
            for (int i = 0; i < 2; i++) {
             
                while (hotelTh[i].IsAlive) ;
            }
            for (int i = 0; i < 5; ++i){
                
                TravelAgency.HotelAvailable = false;}

            for (int i = 0; i < 5; ++i) {
                
                while (travelTh[i].IsAlive) ;
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
