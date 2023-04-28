using System.Text;
using CarDealership.Models;

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

            foreach (Car product in allCars)
            {

                Console.WriteLine($"Id:{product.Id}, Brand: {product.Brand}, Year: {product.Year}, Model: {product.Model}, Color: {product.Color}, Condition: {product.Condition}, Price: {product.Price}, numberOfDoors: {product.NumberOfDoors}");

            }
        }
    }
}
