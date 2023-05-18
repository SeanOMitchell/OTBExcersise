using OTBCodingTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest
{
    internal static class Display
    {
        /// <summary>
        /// Writes information about the given holiday package to the console window.
        /// </summary>
        /// <param name="package">The package to display.</param>
        internal static void DisplayBestPackage(List<HolidayPackage> packages)
        {
            try
            {
                if (packages.Count > 0)
                {
                    HolidayPackage displayPackage = packages[0];

                    Console.WriteLine("Selected package:");
                    Console.WriteLine();
                    Console.WriteLine($"Total Price: £{displayPackage.totalCost}");
                    Console.WriteLine();
                    Console.WriteLine("Flight information:");
                    Console.WriteLine($"Flight id: {displayPackage.flight.id} | Departing from [ {displayPackage.flight.departingFrom} ] | Traveling to [ {displayPackage.flight.travelingTo} ] | Price: £{displayPackage.flight.price}");
                    Console.WriteLine();
                    Console.WriteLine("Hotel information:");
                    Console.WriteLine($"Hotel id: {displayPackage.hotel.id} | Name: {displayPackage.hotel.name} | Price: £{displayPackage.hotel.totalCost}");
                    Console.WriteLine("-----------------------------------");
                }
                else
                {
                    Console.WriteLine("No packages found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DisplayPackage:: Could not display given package | {ex}");
            }
        }
    }
}
