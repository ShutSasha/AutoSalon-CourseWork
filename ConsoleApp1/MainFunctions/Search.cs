using CarDealership.Models;

namespace CarDealership.MainFunctions
{
    internal class Search
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


                if ((brand == "" || car.Brand == brand)
                    && (yearFrom == 0 || car.Year >= yearFrom)
                    && (yearTo == 0 || car.Year <= yearTo)
                    && (model == "" || car.Model == model)
                    && (color == "" || car.Color == color)
                    && (condition == "" || car.Condition == condition)
                    && (priceFrom == 0 || car.Price >= priceFrom)
                    && (priceTo == 0 || car.Price <= priceTo))
                //&& (numberOfDoors == 0 || car.NumberOfDoors == numberOfDoors))
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo matching cars found.");
                Console.ResetColor();
            }

            foreach (string line in linesOfBikes)
            {
                string[] fields = line.Split(',');
                Motorcycle bike = new Motorcycle(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), fields[7]);


                if ((brand == "" || bike.Brand == brand)
                    && (yearFrom == 0 || bike.Year >= yearFrom)
                    && (yearTo == 0 || bike.Year <= yearTo)
                    && (model == "" || bike.Model == model)
                    && (color == "" || bike.Color == color)
                    && (condition == "" || bike.Condition == condition)
                    && (priceFrom == 0 || bike.Price >= priceFrom)
                    && (priceTo == 0 || bike.Price <= priceTo))
                //&& (numberOfDoors == 0 || car.NumberOfDoors == numberOfDoors))
                {
                    matchingBikes.Add(bike);
                }
            }

            // Виводимо знайдені автомобілі
            if (matchingBikes.Count > 0)
            {
                Console.WriteLine("\nMatching bikes:");
                foreach (Motorcycle bike in matchingBikes)
                {
                    Console.WriteLine("Id: {0}, Brand: {1}, Year: {2}, Model: {3}, Color: {4}, Condition: {5}, Price: {6}, MotorcycleType: {7}", bike.Id, bike.Brand, bike.Year, bike.Model, bike.Color, bike.Condition, bike.Price, bike.MotorcycleType);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo matching motorcycle found.");
                Console.ResetColor();
            }


            foreach (string line in linesOfTrucks)
            {
                string[] fields = line.Split(',');
                Truck truck = new Truck(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), int.Parse(fields[7]), int.Parse(fields[8]));


                if ((brand == "" || truck.Brand == brand)
                    && (yearFrom == 0 || truck.Year >= yearFrom)
                    && (yearTo == 0 || truck.Year <= yearTo)
                    && (model == "" || truck.Model == model)
                    && (color == "" || truck.Color == color)
                    && (condition == "" || truck.Condition == condition)
                    && (priceFrom == 0 || truck.Price >= priceFrom)
                    && (priceTo == 0 || truck.Price <= priceTo))
                {
                    matchingTrucks.Add(truck);
                }
            }

            // Виводимо знайдені автомобілі
            if (matchingCars.Count > 0)
            {
                Console.WriteLine("\nMatching trucks:");
                foreach (Truck truck in matchingTrucks)
                {
                    Console.WriteLine("Id: {0}, Brand: {1}, Year: {2}, Model: {3}, Color: {4}, Condition: {5}, Price: {6}, NumberOfWheels: {7}, loadCapacity: {8}", truck.Id, truck.Brand, truck.Year, truck.Model, truck.Color, truck.Condition, truck.Price, truck.NumberOfWheels, truck.LoadCapacity);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo matching trucks found.");
                Console.ResetColor();

            }
        }
    }
}
