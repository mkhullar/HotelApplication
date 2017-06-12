using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml;

namespace HotelTravel
{
    class MultiCellBuffer { 
    const int SIZE = 3;
    int head = 0, tail = 0, nElements = 0;
    string[] buffer = new string[SIZE];

    Semaphore write = new Semaphore(3, 3);
    Semaphore read = new Semaphore(2, 2);


    public void addElement(string order)
    {
        write.WaitOne();
        Console.WriteLine("Thread : " + Thread.CurrentThread.Name + "Entred Write");
        lock (this)
        {
            while (nElements == SIZE)
            {
                    Console.WriteLine("Write Waiting");
                    Monitor.Wait(this);
            }

            buffer[tail] = order;
            tail = (tail + 1) % SIZE;
            Console.WriteLine("Write to the buffer: {0}, {1}", Thread.CurrentThread.Name,nElements);
            nElements++;
            Console.WriteLine("Thread : " + Thread.CurrentThread.Name + "Leaving Write");
            write.Release();
            Monitor.Pulse(this);

        }



    }

    public string getElement()
    {
        read.WaitOne();
        Console.WriteLine("Thread : " + Thread.CurrentThread.Name + "Entred Read");
        lock (this)
        {
            string element;
                XmlDocument document = new XmlDocument();
                while (nElements == 0)
            {
                    Console.WriteLine("Read Waiting");
                Monitor.Wait(this);
            }
            
            element = buffer[head];

            document.LoadXml(element);
                XmlElement rID = document.GetElementById("ReceiverId");
                if (rID == null || Thread.CurrentThread.Name == rID.InnerText)
                {
                    head = (head + 1) % SIZE;
                    nElements--;
                    Console.WriteLine("Read from the buffer: {0} , {1},{2}", DateTime.Now, nElements, element);
                    
                }
                Console.WriteLine("Thread : " + Thread.CurrentThread.Name + "leaving Read");
                read.Release();
                Monitor.Pulse(this);
                return element;
            }

    }
}
}
