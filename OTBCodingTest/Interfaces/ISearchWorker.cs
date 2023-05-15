using OTBCodingTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest.Interfaces
{
    internal interface ISearchWorker
    {
        List<HolidayPackage> SearchFlightsAndHotels(string departFrom, string travelTo, DateTime departureDate, int duration);
    }
}
