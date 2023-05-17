using OTBCodingTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SearchWorker search = new SearchWorker();

            List<HolidayPackage> test = search.SearchFlightsAndHotels(new DateTime(2023, 7, 1), 7, "MAN", "AGP");
            Display.DisplayPackage(test[0]);

            test = search.SearchFlightsAndHotels(new DateTime(2023, 6, 15), 10, "London", "PMI");
            Display.DisplayPackage(test[0]);

            test = search.SearchFlightsAndHotels(new DateTime(2022, 11, 10), 14, null, "LPA");
            Display.DisplayPackage(test[0]);

            Console.ReadLine();
        }
    }
}
