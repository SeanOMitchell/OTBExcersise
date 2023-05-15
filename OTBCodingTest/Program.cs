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

            var test = search.SearchFlightsAndHotels("MAN", "AGP", new DateTime(2023, 7, 1), 7);
            Display.DisplayPackage(test[0]);

            test = search.SearchFlightsAndHotels("MAN", "PMI", new DateTime(2023, 6, 15), 10);
            Display.DisplayPackage(test[0]);

            test = search.SearchFlightsAndHotels("LGW", "AGP", new DateTime(2023, 7, 1), 7);
            Display.DisplayPackage(test[0]);

            Console.ReadLine();
        }
    }
}
