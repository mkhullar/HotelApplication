using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HotelTravel
{
    static class Encoder
    {
        public static string EncodeOrder(Order order)
        {
            using (StringWriter swrite = new StringWriter())
            {
                new XmlSerializer(order.GetType()).Serialize(swrite, order);
                return swrite.ToString();
            }
        }
    }
}
