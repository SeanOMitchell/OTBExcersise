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
using System.Diagnostics;
using OTBCodingTest.Interfaces;

namespace OTBCodingTest
{
    internal class SearchWorker : ISearchWorker
    {
        private List<HotelBooking> hotelBookings = new List<HotelBooking>();
        private List<FlightBooking> flightBookings = new List<FlightBooking>();

        /// <summary>
        /// Reads in flight and hotel information from json files.
        /// File locations are defined in App.config
        /// </summary>
        public SearchWorker()
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

        public List<HolidayPackage> SearchFlightsAndHotels(string departFrom, string travelTo, DateTime departureDate, int duration)
        {
            List<HolidayPackage> retPackages = new List<HolidayPackage>();

            List<FlightBooking> potentialFlights = flightBookings.Where(f => f.departureDate.Date == departureDate.Date && 
                string.Equals(f.departingFrom, departFrom, StringComparison.OrdinalIgnoreCase) && 
                string.Equals(f.travelingTo, travelTo, StringComparison.OrdinalIgnoreCase)).ToList();

            List<HotelBooking> potentialHotels = hotelBookings.Where(h => h.arrivalDate.Date == departureDate.Date &&
            h.localAirports.Contains(travelTo) && 
            h.nights == duration).ToList();

            retPackages = potentialFlights.SelectMany(f => potentialHotels.Select(h => new HolidayPackage(f, h))).OrderBy(p => p.totalCost).ToList();

            return retPackages;
        }
    }
}
