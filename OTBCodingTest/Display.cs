using OTBCodingTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBCodingTest
{
    internal class Display
    {
        internal void DisplayPackage(HolidayPackage package)
        {
            Console.WriteLine("Selected package:");
            Console.WriteLine();
            Console.WriteLine($"Total Price: {package.totalCost}");
            Console.WriteLine();
            Console.WriteLine("Flight information:");
            Console.WriteLine($"Flight id: {package.flight.id} | Departing from [ {package.flight.from} ] | Traveling to [ {package.flight.to} ] | Price: {package.flight.price}");
            Console.WriteLine();
            Console.WriteLine("Hotel information:");
            Console.WriteLine($"Hotel id: {package.hotel.id} | Name: {package.hotel.name} | Price: {package.hotel.totalCost}");
            Console.WriteLine("-----------------------------------");
        }
    }
}
