using System;
using System.IO;
using System.Text;

namespace CarDealership.MainFunctions
{
    internal class AddCar
    {
        static public void AddCarToFileMethod()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть назву бренду(Audi) машини: ");
            string brand = Console.ReadLine();

            Console.Write("Введіть рік випуску(2020): ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Введіть модель автомобіля(A3): ");
            string model = Console.ReadLine();

            Console.Write("Введіть колір автомобіля(red): ");
            string color = Console.ReadLine();

            Console.Write("Введіть стан автомобіля(good, normal): ");
            string condition = Console.ReadLine();

            Console.Write("Введіть ціну автомобіля(14500): ");
            int price = int.Parse(Console.ReadLine());


            string fileName = "File.txt";
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\MainFunctions"));
            string filePath = Path.Combine(projectPath, fileName);

            string[] lines = File.ReadAllLines(filePath);
            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;

            //string fileName = "File.txt";
            //string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);


            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{id},{brand},{year},{model},{color},{condition},{price}");
            }

            Console.WriteLine("Car added to file successfully!");
        }
    }
}
