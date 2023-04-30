﻿using CarDealership.ValidatorsMethods;
using System.Text;

namespace CarDealership.MainFunctions.CarFunctions
{
    internal class AddCar
    {
        static public void AddCarToFileMethod()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть назву бренду(Audi) машини: ");
            string? brand = Console.ReadLine();

            int year = Validators.YearInputOfVehicle();

            Console.Write("Введіть модель автомобіля(A3): ");
            string? model = Console.ReadLine();

            Console.Write("Введіть колір автомобіля(red): ");
            string? color = Console.ReadLine();

            Console.Write("Введіть стан автомобіля(good, normal): ");
            string? condition = Console.ReadLine();

            Console.Write("Введіть ціну автомобіля(14500): ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість дверей автомобіля(4): ");
            int numberOfDoors = int.Parse(Console.ReadLine());

            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[]? lines = accessFile.Lines;
            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;


            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{id},{brand},{year},{model},{color},{condition},{price},{numberOfDoors}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCar added to file successfully!");
            Console.ResetColor();
        }
    }
}