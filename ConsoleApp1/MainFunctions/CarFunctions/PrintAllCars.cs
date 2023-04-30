using System.Text;
using CarDealership.Models;
using ConsoleTables;

namespace CarDealership.MainFunctions.CarFunctions
{
    internal class PrintCars
    {
        static public void PrintCarsMethod()
        {
            Console.OutputEncoding = Encoding.UTF8;

            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[] lines = accessFile.Lines;
            var allCars = CarImporter.ImportCarsFromFile(lines);

            var table = new ConsoleTable("ID", "Brand", "Year", "Model", "Color", "Condition", "Price", "numberOfDoors");

            foreach (Car product in allCars)
            {

                table.AddRow(
                    product.Id,
                    product.Brand,
                    product.Year,
                    product.Model,
                    product.Color,
                    product.Condition,
                    product.Price,
                    product.NumberOfDoors
                    );

            }
            Console.Write(table.ToString());
        }

    }
}
