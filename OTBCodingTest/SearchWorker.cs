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
        public SearchWorker(string flightDataLocation = "", string hotelDataLocation = "")
        {
            try
            {

                if (string.IsNullOrEmpty(flightDataLocation))
                {
                    flightDataLocation = ConfigurationManager.AppSettings["flightData"];
                }             
                if (File.Exists(flightDataLocation))
                {
                    string flightInfo = File.ReadAllText(flightDataLocation);
                    flightBookings = JsonConvert.DeserializeObject<List<FlightBooking>>(flightInfo);
                }
                else
                {
                    Console.WriteLine("No flight data found");
                }

                if (string.IsNullOrEmpty(hotelDataLocation))
                {
                    hotelDataLocation = ConfigurationManager.AppSettings["hotelData"];
                }
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

            try
            {
                //Initial narrowing down ot flights and hotels - based upon required criteria
                List<FlightBooking> potentialFlights = flightBookings.Where(f => f.departureDate.Date == departureDate.Date).ToList();
                List<HotelBooking> potentialHotels = hotelBookings.Where(h => h.arrivalDate.Date == departureDate.Date && h.nights == duration).ToList();

                //If not allowing all airports for departure
                if (!string.IsNullOrEmpty(departFrom))
                {
                    //Since all airport codes are 3 chars long, if over that then assume a location is given
                    if (departFrom.Length > 3)
                {
                        //Searches dictionary of locations for all airports at the given location..
                    List<string> airportsAtLocation = airportLocations.Where(l => l.Value == departFrom).Select(l => l.Key).ToList();

                        //..and filter flights accordingly
                        potentialFlights = potentialFlights.Where(f => airportsAtLocation.Contains(f.departingFrom, StringComparer.CurrentCultureIgnoreCase)).ToList();
                }
                else
                {
                        //Filter to only flights from the single provided airport
                        potentialFlights = potentialFlights.Where(f => string.Equals(f.departingFrom, departFrom, StringComparison.OrdinalIgnoreCase)).ToList();
                    }
                }

                //If not allowing all airports for the destination
                if (!string.IsNullOrEmpty(travelTo))
                {
                    //Same logic as above ^
                    if (travelTo.Length > 3)
                    {
                        List<string> airportsAtLocation = airportLocations.Where(l => l.Value == travelTo).Select(l => l.Key).ToList();

                        //Filter flights as above ^..
                        potentialFlights = potentialFlights.Where(f => airportsAtLocation.Contains(f.travelingTo, StringComparer.CurrentCultureIgnoreCase)).ToList();
                        //..and also filter hotels - if any hotels at the given location are listed as a local_airport
                        potentialHotels = potentialHotels.Where(h => h.localAirports.Any(la => airportsAtLocation.Contains(la, StringComparer.CurrentCultureIgnoreCase))).ToList();
                    }
                    else
                    {
                        //Filter to only flights and hotels from the single provided airport
                        potentialFlights = potentialFlights.Where(f => string.Equals(f.travelingTo, travelTo, StringComparison.OrdinalIgnoreCase)).ToList();
                        potentialHotels = potentialHotels.Where(h => h.localAirports.Contains(travelTo, StringComparer.CurrentCultureIgnoreCase)).ToList();
                    }
                }

                //Select all combinations of flights and hotels, ordering by cheapest -> most expensive
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
