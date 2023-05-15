using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest.Classes
{
    internal class FlightBooking : Flight
    {
        [JsonProperty("id")]
        internal int id;
        [JsonProperty("departure_date")]
        internal DateTime departureDate;
    }
}
