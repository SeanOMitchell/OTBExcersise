using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest.Classes
{
    internal class Flight
    {
        [JsonProperty("airline")]
        internal string airline;
        [JsonProperty("from")]
        internal string from;
        [JsonProperty("to")]
        internal string to;
        [JsonProperty("price")]
        internal int price; //Assuming price is fixed, if dependant on times should be moved to FlightBooking
    }
}
