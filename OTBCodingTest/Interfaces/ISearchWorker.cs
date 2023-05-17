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
        List<HolidayPackage> SearchFlightsAndHotels(DateTime departureDate, int duration, string departFrom = "", string travelTo = "");
    }
}
