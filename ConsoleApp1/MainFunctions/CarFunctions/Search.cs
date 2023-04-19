using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.MainFunctions.CarFunctions
{
    internal class Search
    {

        public static void SearchMethod()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[] lines = accessFile.Lines;

            List<Car> matchingCars = new List<Car>();

            Console.Write("Enter the brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter the year from: ");
            int yearFrom;
            int.TryParse(Console.ReadLine(), out yearFrom);
            Console.Write("Enter the year to: ");
            int yearTo;
            int.TryParse(Console.ReadLine(), out yearTo);
            Console.Write("Enter the model: ");
            string model = Console.ReadLine();
            Console.Write("Enter the color: ");
            string color = Console.ReadLine();
            Console.Write("Enter the condition: ");
            string condition = Console.ReadLine();
            Console.Write("Enter the price from: ");
            int priceFrom;
            int.TryParse(Console.ReadLine(), out priceFrom);
            Console.Write("Enter the price to: ");
            int priceTo;
            int.TryParse(Console.ReadLine(), out priceTo);
            Console.Write("Enter the number of doors: ");
            int numberOfDoors;
            int.TryParse(Console.ReadLine(), out numberOfDoors);

            // Шукаємо всі автомобілі, які відповідають критеріям
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                Car car = new Car(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), int.Parse(fields[7]));


                if ((brand == "" || car.Brand == brand)
                    && (yearFrom == 0 || car.Year >= yearFrom)
                    && (yearTo == 0 || car.Year <= yearTo)
                    && (model == "" || car.Model == model)
                    && (color == "" || car.Color == color)
                    && (condition == "" || car.Condition == condition)
                    && (priceFrom == 0 || car.Price >= priceFrom)
                    && (priceTo == 0 || car.Price <= priceTo)
                    && (numberOfDoors == 0 || car.NumberOfDoors == numberOfDoors))
                {
                    matchingCars.Add(car);
                }
            }

            // Виводимо знайдені автомобілі
            if (matchingCars.Count > 0)
            {
                Console.WriteLine("\nMatching cars:");
                foreach (Car car in matchingCars)
                {
                    Console.WriteLine("Id: {0}, Brand: {1}, Year: {2}, Model: {3}, Color: {4}, Condition: {5}, Price: {6}, NumberOfDoors: {7}", car.Id, car.Brand, car.Year, car.Model, car.Color, car.Condition, car.Price, car.NumberOfDoors);
                }
            }
            else
            {
                Console.WriteLine("No matching cars found.");
            }

        }


    }


}
