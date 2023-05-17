using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest.Classes
{
    public class Flight
    {
        [JsonProperty("airline")]
        internal string airline;
        [JsonProperty("from")]
        internal string departingFrom;
        [JsonProperty("to")]
        internal string travelingTo;
        [JsonProperty("price")]
        internal int price; //Assuming price is fixed, if dependant on times should be moved to FlightBooking
    }
}
