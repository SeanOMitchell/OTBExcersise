using OTBCodingTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest.Classes
{
    internal class HolidaySearch
    {
        private string departingFrom { get; set; }
        private string travelingTo { get; set; }
        private DateTime departureDate { get; set; }
        private int duration { get; set; }

        public HolidaySearch(string departingFrom, string travelingTo, DateTime departureDate, int duration)
        {
            this.departingFrom = departingFrom;
            this.travelingTo = travelingTo;
            this.departureDate = departureDate;
            this.duration = duration;
        }

        public HolidayPackage getPackage(string departingFrom, string travelingTo, DateTime departureDate, int duration)
        {
            return new HolidayPackage(new FlightBooking(), new HotelBooking());
        }
    }
}
