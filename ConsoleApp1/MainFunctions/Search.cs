using CarDealership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.MainFunctions
{
    internal class Search
    {

        public void SearchMethod()
        {
            string fileName = "File.txt";
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\MainFunctions"));
            string filePath = Path.Combine(projectPath, fileName);
            string[] lines = File.ReadAllLines(filePath);

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

            // Шукаємо всі автомобілі, які відповідають критеріям
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                Car car = new()
                {
                    Id = int.Parse(fields[0]),
                    Brand = fields[1],
                    Year = int.Parse(fields[2]),
                    Model = fields[3],
                    Color = fields[4],
                    Condition = fields[5],
                    Price = int.Parse(fields[6])
                };

                if ((brand == "" || car.Brand == brand)
                    && (yearFrom == 0 || car.Year >= yearFrom)
                    && (yearTo == 0 || car.Year <= yearTo)
                    && (model == "" || car.Model == model)
                    && (color == "" || car.Color == color)
                    && (condition == "" || car.Condition == condition)
                    && (priceFrom == 0 || car.Price >= priceFrom)
                    && (priceTo == 0 || car.Price <= priceTo))
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
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", car.Id, car.Brand, car.Year, car.Model, car.Color, car.Condition, car.Price);
                }
            }
            else
            {
                Console.WriteLine("No matching cars found.");
            }

        }


    }


}
