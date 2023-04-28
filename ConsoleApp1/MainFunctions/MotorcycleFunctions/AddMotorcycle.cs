using System;
using System.IO;
using System.Text;

namespace CarDealership.MainFunctions
{
    internal class AddMotorcycle
    {
        public static void AddMotorcycleToFileMethod()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть назву бренду(Honda) мотоцикла: ");
            string? brand = Console.ReadLine();

            Console.Write("Введіть рік випуску(2022): ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Введіть модель мотоцикла(CBR500R): ");
            string? model = Console.ReadLine();

            Console.Write("Введіть колір мотоцикла(black): ");
            string? color = Console.ReadLine();

            Console.Write("Введіть стан мотоцикла(good, normal): ");
            string? condition = Console.ReadLine();

            Console.Write("Введіть ціну мотоцикла(8000): ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Введіть тип мотоцикла(sport, cruiser): ");
            string? motorcycleType = Console.ReadLine();

            AccessFile accessFile = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            string[] lines = accessFile.Lines;
            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;

            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{id},{brand},{year},{model},{color},{condition},{price},{motorcycleType}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nMotorcycle added to file successfully!");
            Console.ResetColor();
        }
    }
}
