using System;
using System.IO;
using System.Text;

namespace CarDealership.MainFunctions
{
    internal class AddVehicle
    {
        public static void AddVehicleToFileMethod(string vehicleType)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write($"Введіть назву бренду(Honda) {vehicleType}: ");
            string brand = Console.ReadLine();

            Console.Write($"Введіть рік випуску(2022) {vehicleType}: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write($"Введіть модель {vehicleType}(CBR500R): ");
            string model = Console.ReadLine();

            Console.Write($"Введіть колір {vehicleType}(black): ");
            string color = Console.ReadLine();

            Console.Write($"Введіть стан {vehicleType}(good, normal): ");
            string condition = Console.ReadLine();

            Console.Write($"Введіть ціну {vehicleType}(8000): ");
            int price = int.Parse(Console.ReadLine());

            AccessFile accessFile = AccessFile.GetAccessToFile($"{vehicleType}DB.txt", $"..\\..\\..\\MainFunctions\\{vehicleType}Functions");
            string[] lines = accessFile.Lines;
            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;

            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{id},{brand},{year},{model},{color},{condition},{price},{vehicleType}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{vehicleType} added to file successfully!");
            Console.ResetColor();
        }
    }
}