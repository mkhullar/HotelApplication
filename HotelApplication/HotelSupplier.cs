using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelTravel
{
    
    class HotelSupplier
    {
        private int pCuts_MAX = 10;
        private int pCuts = 1;
        private double currPrice = 0.0;
        private double prevPrice = 0.0;
        public delegate void priceCutEventHandler(PCutEventArgs pr);
        public event priceCutEventHandler PriceCut;
        private ArrayList processingThreads = new ArrayList();
        private static Random random =  new Random();
        public void Run()
        {
            
            while(pCuts <= pCuts_MAX)
            {
                Console.WriteLine("Enter While ...");
                setPrice();
                if (prevPrice > currPrice)
                { PriceCutEvent(); }
                else
                {
                    Console.WriteLine("No Price Cut");
                }
                prevPrice = currPrice;

                //Process Order Implement
                ProcessOrder(RetrieveOrder());
                Console.WriteLine("Exit While ...");
            }
            Console.WriteLine("Enter Wait...");
            foreach (Thread item in processingThreads)
            {
                while (item.IsAlive) ;
            }
            Console.WriteLine("Hotel Supp End...");
        }
        private void PriceCutEvent()
        {
            if (PriceCut != null)
            {
                Console.WriteLine("Price cut Event performed..." + pCuts++ + Thread.CurrentThread.Name);
                PriceCut(new PCutEventArgs(Thread.CurrentThread.Name, currPrice));
            }
        }

        private void setPrice()
        {
            Console.WriteLine("Statring calculations" + Thread.CurrentThread.Name);
            prevPrice = currPrice;
            currPrice = MoneyModel.getRates(random.Next(1,10));
        }


        private Order RetrieveOrder(){
            Console.WriteLine("Retreive Order: " );
            return Decoder.DecodeOrder(Program.mbuff.getElement());
        }

        public void ProcessOrder(Order order)
        {
            Console.WriteLine("Process Order First Line "+order.RecieverId);
            if(order.RecieverId == Thread.CurrentThread.Name || order.RecieverId == null)
            {
                Console.WriteLine("Order for " + Thread.CurrentThread.Name + " Recieved");
                OrderProcessing processor = new OrderProcessing(order,currPrice);
                Thread processTh = new Thread(new ThreadStart(processor.ProcessOrder));
                processingThreads.Add(processTh);
                processTh.Name = "Supply_" + Thread.CurrentThread.Name;
                processTh.Start();
            }
        }
    }
}
