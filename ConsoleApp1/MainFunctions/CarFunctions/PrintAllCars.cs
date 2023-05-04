using CarDealership.Models;
using ConsoleTables;

namespace CarDealership.MainFunctions.CarFunctions
{
    internal class PrintCars
    {
        public static void PrintCarsMethod()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[] lines = accessFile.Lines;
            var Cars = CarImporter.ImportCarsFromFile(lines);

            var table = new ConsoleTable("ID", "Brand", "Year", "Model", "Color", "Condition", "Price ($)", "numberOfDoors");

            foreach (Car car in Cars)
            {
               Print.AddVehicleToTable(car, table);
            }
            Console.Write(table.ToString());
        }
    }
}
