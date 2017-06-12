using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HotelTravel
{
    class Decoder
    {
        public static Order DecodeOrder(string encodedOrder)

        {
            using (TextReader tr = new StringReader(encodedOrder))
            {
                return (Order)new XmlSerializer(typeof(Order)).Deserialize(tr);
            }
        }
    }
}
