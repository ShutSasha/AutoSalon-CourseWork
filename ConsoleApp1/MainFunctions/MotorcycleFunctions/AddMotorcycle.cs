using System;
using System.IO;
using System.Text;

namespace CarDealership.MainFunctions
{
    internal class AddMotorcycle
    {
        static public void AddMotorcycleToFileMethod()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть назву бренду(Audi) мотоцикла: ");
            string brand = Console.ReadLine();

            Console.Write("Введіть рік випуску(2020): ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Введіть модель мотоцикла(A3): ");
            string model = Console.ReadLine();

            Console.Write("Введіть колір мотоцикла(red): ");
            string color = Console.ReadLine();

            Console.Write("Введіть стан мотоцикла(good, normal): ");
            string condition = Console.ReadLine();

            Console.Write("Введіть ціну мотоцикла(14500): ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість колес(1-4): ");
            int numberOfWheels = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість колес(1-4): ");
            string motorcycle = Console.ReadLine();


            AccessFile accessFileOfMotorcycle = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            string[] lines = accessFileOfMotorcycle.Lines;
            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;


            using (StreamWriter writer = new StreamWriter(accessFileOfMotorcycle.FilePath, true))
            {
                writer.WriteLine($"{id},{brand},{year},{model},{color},{condition},{price},{numberOfWheels},{motorcycle}");
            }

            Console.WriteLine("Motorcycle added to file successfully!");
        }
    }
}
