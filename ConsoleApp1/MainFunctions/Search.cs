using CarDealership.Models;
using ConsoleTables;
using CarDealership.MainFunctions.CarFunctions;
using CarDealership.MainFunctions.MotorcycleFunctions;
using CarDealership.MainFunctions.TruckFunctions;

namespace CarDealership.MainFunctions
{
    public class Search
    {

        public static void SearchMethod()
        {
            AccessFile accessFileOfCars = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[] linesOfCars = accessFileOfCars.Lines;

            AccessFile accessFileOfBikes = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            string[] linesOfBikes = accessFileOfBikes.Lines;

            AccessFile accessFileOfTrucks = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            string[] linesOfTrucks = accessFileOfTrucks.Lines;

            List<Car> matchingCars = new List<Car>();
            List<Motorcycle> matchingBikes = new List<Motorcycle>();
            List<Truck> matchingTrucks = new List<Truck>();


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
            foreach (string line in linesOfCars)
            {
                string[] fields = line.Split(',');
                Car car = new Car(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), int.Parse(fields[7]));


                if (CheckOfMatchingVehicle(car))
                {
                    matchingCars.Add(car);
                }
            }

            // Виводимо знайдені автомобілі
            if (matchingCars.Count > 0)
            {
                Console.WriteLine("\nMatching cars:");
                var tableForCar = new ConsoleTable("ID", "Brand", "Year", "Model", "Color", "Condition", "Price", "numberOfDoors");
                foreach (Car car in matchingCars)
                {
                    PrintCars.AddCarRowToTable(car, tableForCar);
                }

                Console.Write(tableForCar.ToString());
            }
            else
            {
                OutputError("cars");
            }

            foreach (string line in linesOfBikes)
            {
                string[] fields = line.Split(',');
                Motorcycle bike = new Motorcycle(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), fields[7]);


                if (CheckOfMatchingVehicle(bike))
                {
                    matchingBikes.Add(bike);
                }
            }

            // Виводимо знайдені автомобілі
            if (matchingBikes.Count > 0)
            {
                Console.WriteLine("\nMatching bikes:");
                var tableForBike = new ConsoleTable("ID", "Бренд", "Рік випуску", "Модель", "Колір", "Стан", "Ціна", "Тип мотоцикла");
                foreach (Motorcycle bike in matchingBikes)
                {
                    PrintMotorcycle.AddBikeRowToTable(bike, tableForBike);
                }
                Console.Write(tableForBike.ToString());
            }
            else
            {
                OutputError("bikes");
            }


            foreach (string line in linesOfTrucks)
            {
                string[] fields = line.Split(',');
                Truck truck = new Truck(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), int.Parse(fields[7]), int.Parse(fields[8]));


                if (CheckOfMatchingVehicle(truck))
                {
                    matchingTrucks.Add(truck);
                }
            }

            // Виводимо знайдені автомобілі
            if (matchingTrucks.Count > 0)
            {
                Console.WriteLine("\nMatching trucks:");
                var tableForTruck = new ConsoleTable("ID", "Бренд", "Рік випуску", "Модель", "Колір", "Стан", "Ціна", "Кількість коліс", "Грузопідйомність(У тоннах)");
                foreach (Truck truck in matchingTrucks)
                {
                    PrintTruck.AddTruckRowToTable(truck, tableForTruck);
                }
                Console.Write(tableForTruck.ToString());
            }
            else
            {
                OutputError("trucks");
            }

            bool CheckOfMatchingVehicle(Vehicle vehicle)
            {
                bool check = false;
                if ((brand == "" || vehicle.Brand == brand)
                 && (yearFrom == 0 || vehicle.Year >= yearFrom)
                 && (yearTo == 0 || vehicle.Year <= yearTo)
                 && (model == "" || vehicle.Model == model)
                 && (color == "" || vehicle.Color == color)
                 && (condition == "" || vehicle.Condition == condition)
                 && (priceFrom == 0 || vehicle.Price >= priceFrom)
                 && (priceTo == 0 || vehicle.Price <= priceTo))
                {
                    check = true;
                }

                return check;
            }

            void OutputError(string vehicle)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nNo matching {vehicle} found.");
                Console.ResetColor();
            }
        }
    }
}
