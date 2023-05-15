using Newtonsoft.Json;
using OTBCodingTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace OTBCodingTest
{
    internal class ProcessSearch
    {
        public List<HotelBooking> hotelBookings = new List<HotelBooking>();
        public List<FlightBooking> flightBookings = new List<FlightBooking>();

        /// <summary>
        /// Reads in flight and hotel information from json files.
        /// File locations are defined in App.config
        /// </summary>
        public ProcessSearch()
        {
            try
            {
                string flightDataLocation = ConfigurationManager.AppSettings["flightData"];
                if (File.Exists(flightDataLocation))
                {
                    string flightInfo = File.ReadAllText(flightDataLocation);
                    flightBookings = JsonConvert.DeserializeObject<List<FlightBooking>>(flightInfo);
                }
                else
                {
                    Console.WriteLine("No flight data found");
                }

                string hotelDataLocation = ConfigurationManager.AppSettings["hotelData"];
                if (File.Exists(hotelDataLocation))
                {
                    string hotelInfo = File.ReadAllText(hotelDataLocation);
                    hotelBookings = JsonConvert.DeserializeObject<List<HotelBooking>>(hotelInfo);
                }
                else
                {
                    Console.WriteLine("No hotel data found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ProcessSearch:: Error whilst parsing information | {ex}");
            }
        }
    }
}
