using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest.Classes
{
    internal class HolidayPackage
    {
        internal FlightBooking flight;
        internal HotelBooking hotel;

        internal int totalCost
        {
            get
            {
                return flight.price + hotel.totalCost;
            }
        }

        public HolidayPackage()
        {
            flight = new FlightBooking();
            hotel = new HotelBooking();
        }

        public HolidayPackage(FlightBooking flight, HotelBooking hotel)
        {
            this.flight = flight;
            this.hotel = hotel;
        }
    }
}
