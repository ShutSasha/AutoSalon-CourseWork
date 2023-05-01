using System.Text;
using CarDealership.Models;
using ConsoleTables;

namespace CarDealership.MainFunctions.CarFunctions
{
    internal class PrintCars
    {
        public static void PrintCarsMethod()
        {
            Console.OutputEncoding = Encoding.UTF8;

            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[] lines = accessFile.Lines;
            var allCars = CarImporter.ImportCarsFromFile(lines);

            var table = new ConsoleTable("ID", "Brand", "Year", "Model", "Color", "Condition", "Price", "numberOfDoors");

            foreach (Car product in allCars)
            {

                AddCarRowToTable(product, table);

            }
            Console.Write(table.ToString());
        }

        public static void AddCarRowToTable(Car car, ConsoleTable table)
        {
            table.AddRow(
                car.Id,
                car.Brand,
                car.Year,
                car.Model,
                car.Color,
                car.Condition,
                car.Price,
                car.NumberOfDoors
            );
        }
    }
}
