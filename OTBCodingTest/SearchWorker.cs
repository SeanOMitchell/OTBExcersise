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
    public class SearchWorker : ISearchWorker
    {
        private List<HotelBooking> hotelBookings = new List<HotelBooking>();
        private List<FlightBooking> flightBookings = new List<FlightBooking>();

        //Originally going to go with enums, but would have required too many - this allows simple lookups
        private Dictionary<string, string> airportLocations = new Dictionary<string, string>
        {
            { "MAN", "Manchester"},
            { "TFS", "Tenerife" },
            { "AGP", "Malaga" },
            { "PMI", "Palma" },
            { "LTN", "London" },
            { "LGW", "London" },
            { "LPA", "Gran Canaria" },
        };

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

        public List<HolidayPackage> SearchFlightsAndHotels(DateTime departureDate, int duration, string departFrom = "", string travelTo = "")
        {
            List<HolidayPackage> retPackages = new List<HolidayPackage>();

            List<FlightBooking> potentialFlights = new List<FlightBooking>();

            try
            {
                if (string.IsNullOrEmpty(departFrom))
                {
                    potentialFlights = flightBookings.Where(f => f.departureDate.Date == departureDate.Date &&
                    string.Equals(f.travelingTo, travelTo, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else if (departFrom.Length > 3)
                {
                    List<string> airportsAtLocation = airportLocations.Where(l => l.Value == departFrom).Select(l => l.Key).ToList();

                    potentialFlights = flightBookings.Where(f => f.departureDate.Date == departureDate.Date &&
                    airportsAtLocation.Contains(f.departingFrom, StringComparer.CurrentCultureIgnoreCase) &&
                    string.Equals(f.travelingTo, travelTo, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    potentialFlights = flightBookings.Where(f => f.departureDate.Date == departureDate.Date &&
                string.Equals(f.departingFrom, departFrom, StringComparison.OrdinalIgnoreCase) && 
                string.Equals(f.travelingTo, travelTo, StringComparison.OrdinalIgnoreCase)).ToList();
                }

            List<HotelBooking> potentialHotels = hotelBookings.Where(h => h.arrivalDate.Date == departureDate.Date &&
            h.localAirports.Contains(travelTo) && 
            h.nights == duration).ToList();

            retPackages = potentialFlights.SelectMany(f => potentialHotels.Select(h => new HolidayPackage(f, h))).OrderBy(p => p.totalCost).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SearchFlightsAndHotels:: Error whilst searching for packages | {ex}");
            }

            return retPackages;
        }
    }
}
