using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OTBCodingTest;
using OTBCodingTest.Classes;
using System.Configuration;

namespace UnitTests
{
    [TestClass]
    public class PackageSearchTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string departingFrom = "MAN";
            string arrivingAt = "AGP";
            DateTime departureDate = new DateTime(2023, 7, 1);
            int duration = 7;

            string flightDataLocation = @"C:\Users\Sean\Documents\CodeTest\FlightInfo.json";
            string hotelDataLocation = @"C:\Users\Sean\Documents\CodeTest\HotelInfo.json";

            SearchWorker search = new SearchWorker(flightDataLocation, hotelDataLocation);
            List<HolidayPackage> test = search.SearchFlightsAndHotels(departureDate, duration, departingFrom, arrivingAt);

            int expectedFlightId = 2;
            int expectedHotelId = 9;
            Assert.IsTrue(test[0].flight.id == expectedFlightId && test[0].hotel.id == expectedHotelId, "Incorrect HolidayPackage");               
        }

        [TestMethod]
        public void TestMethod2()
        {
            string departingFrom = "London";
            string arrivingAt = "PMI";
            DateTime departureDate = new DateTime(2023, 6, 15);
            int duration = 10;

            string flightDataLocation = @"C:\Users\Sean\Documents\CodeTest\FlightInfo.json";
            string hotelDataLocation = @"C:\Users\Sean\Documents\CodeTest\HotelInfo.json";

            SearchWorker search = new SearchWorker(flightDataLocation, hotelDataLocation);
            List<HolidayPackage> test = search.SearchFlightsAndHotels(departureDate, duration, departingFrom, arrivingAt);

            int expectedFlightId = 6;
            int expectedHotelId = 5;
            Assert.IsTrue(test[0].flight.id == expectedFlightId && test[0].hotel.id == expectedHotelId, "Incorrect HolidayPackage");
        }

        [TestMethod]
        public void TestMethod3()
        {
            string departingFrom = "";
            string arrivingAt = "LPA";
            DateTime departureDate = new DateTime(2022, 11, 10);
            int duration = 14;

            string flightDataLocation = @"C:\Users\Sean\Documents\CodeTest\FlightInfo.json";
            string hotelDataLocation = @"C:\Users\Sean\Documents\CodeTest\HotelInfo.json";

            SearchWorker search = new SearchWorker(flightDataLocation, hotelDataLocation);
            List<HolidayPackage> test = search.SearchFlightsAndHotels(departureDate, duration, departingFrom, arrivingAt);

            int expectedFlightId = 7;
            int expectedHotelId = 6;
            Assert.IsTrue(test[0].flight.id == expectedFlightId && test[0].hotel.id == expectedHotelId, "Incorrect HolidayPackage");
        }
    }
}
