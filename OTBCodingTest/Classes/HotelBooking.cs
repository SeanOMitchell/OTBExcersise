using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest.Classes
{
    public class HotelBooking : Hotel
    {
        [JsonProperty("id")]
        public int id;
        [JsonProperty("arrival_date")]
        internal DateTime arrivalDate;
        [JsonProperty("nights")]
        internal int nights;

        internal int totalCost
        {
            get
            {
                return nights * pricePerNight;
            }
        }
    }
}
