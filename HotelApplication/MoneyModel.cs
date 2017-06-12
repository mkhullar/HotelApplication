using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravel
{
    class MoneyModel
    {
        private const double baseRate = 75.0; 

        private const int lowSpan = 4;
        private const int midSpan = 7;

        private const double lowSpanAdjust = 1.0;
        private const double midSpanAdjust = .75; 
        private const double highSpanAdjust = .5;

        public static double getRates(int occupancy)
        {
            return (baseRate * spanAdjust(occupancy));

        }

        private static double spanAdjust(int occupancy)
        {
            if (occupancy < lowSpan)
            {
                return lowSpanAdjust;
            }
            else if (occupancy < midSpan)
            {
                return midSpanAdjust;
            }
            else
            {
                return highSpanAdjust;
            }
        }
    }
}
