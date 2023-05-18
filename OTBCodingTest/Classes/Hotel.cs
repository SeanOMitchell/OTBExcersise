using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest.Classes
{
    /// <summary>
    /// A hotel
    /// </summary>
    public class Hotel
    {
        [JsonProperty("id")]
        public int id;
        [JsonProperty("name")]
        internal string name;
        [JsonProperty("price_per_night")]
        internal int pricePerNight; //Assuming price is fixed, if dependant on when the booking is should be moved to HotelBooking
        [JsonProperty("local_airports")]
        internal string[] localAirports;
    }
}
