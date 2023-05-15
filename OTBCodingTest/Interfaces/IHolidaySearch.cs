using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest.Interfaces
{
    internal interface IHolidaySearch
    {
        string departingFrom { get; set; }
        string travelingTo { get; set; }
        DateTime departureDate { get; set; }
        int duration { get; set; }
        
    }
}
