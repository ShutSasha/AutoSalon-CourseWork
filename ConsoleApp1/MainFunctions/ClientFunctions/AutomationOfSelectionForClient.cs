using CarDealership.Models;
using CarDealership.Utils;
using static CarDealership.MainFunctions.ExitOrContinue;

namespace CarDealership.MainFunctions.ClientFunctions
{
    public class AutomationOfSelectionForClient
    {
        public static void AutomationSearch()
        {
            List<Client> allClients = new List<Client>();

            AccessFile accessFileOfClients = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");
            string[] linesClients = accessFileOfClients.Lines;


            foreach (string line in linesClients)
            {
                string[] values = line.Split(',');

                int idClient = int.Parse(values[0]);
                string name = values[1] != "0" ? values[1] : "Даних немає";
                string phone = values[2] != "0" ? values[2] : "Даних немає";
                string email = values[3] != "0" ? values[3] : "Даних немає";
                string preferredBrand = values[4] != "0" ? values[4] : "Даних немає";
                int minPrice = values[5] != "0" ? int.Parse(values[5]) : 0;
                int maxPrice = values[6] != "0" ? int.Parse(values[6]) : 9999999;
                int minYear = values[7] != "0" ? int.Parse(values[7]) : 1900;
                int maxYear = values[8] != "0" ? int.Parse(values[8]) : 2023;

                Client newClient = new Client(idClient, name, phone, email, preferredBrand, minPrice, maxPrice, minYear, maxYear);

                allClients.Add(newClient);
            }

            PrintClients.PrintAllClients();

            MenuText.BlueOutput("\nВиберіть id клієнта для якого хочете зробити автоматичний підбір транспорту: ");

            int id = Convert.ToInt32(Console.ReadLine());

            AccessFile accessFileOfCar = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[] lines = accessFileOfCar.Lines;

            List<Car> matchingCars = new List<Car>();

            int priceFrom = allClients[id - 1].MinPrice;
            int priceTo = allClients[id - 1].MaxPrice;
            int yearFrom = allClients[id - 1].MinYear;
            int yearTo = allClients[id - 1].MaxYear;

            foreach (string line in lines)
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

                MenuText.BlueOutput("\nMatching cars:\n");

                foreach (Car car in matchingCars)
                {
                    Console.WriteLine("Id: {0}, Brand: {1}, Year: {2}, Model: {3}, Color: {4}, Condition: {5}, Price: {6}, NumberOfDoors: {7}", car.Id, car.Brand, car.Year, car.Model, car.Color, car.Condition, car.Price, car.NumberOfDoors);
                }
            }
            else
            {
                MenuText.OutputErrorOfNoMatchingVehicle("cars");
            }


            AccessFile accessFileOfMotorcycle = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            string[] linesOfBike = accessFileOfMotorcycle.Lines;

            List<Motorcycle> matchingBikes = new List<Motorcycle>();

            foreach (string line in linesOfBike)
            {
                string[] fields = line.Split(',');
                Motorcycle bike = new Motorcycle(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), fields[7]);


                if (CheckOfMatchingVehicle(bike))
                {
                    matchingBikes.Add(bike);
                }
            }


            if (matchingBikes.Count > 0)
            {
                MenuText.BlueOutput("\nMatching bikes:\n");

                foreach (Motorcycle bike in matchingBikes)
                {
                    Console.WriteLine("Id: {0}, Brand: {1}, Year: {2}, Model: {3}, Color: {4}, Condition: {5}, Price: {6}, bikeType: {7}", bike.Id, bike.Brand, bike.Year, bike.Model, bike.Color, bike.Condition, bike.Price, bike.MotorcycleType);
                }
            }
            else
            {
                MenuText.OutputErrorOfNoMatchingVehicle("bikes");
            }


            AccessFile accessFileOfTruck = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            string[] linesOfTruck = accessFileOfTruck.Lines;

            List<Truck> matchingTrucks = new List<Truck>();

            foreach (string line in linesOfTruck)
            {
                string[] fields = line.Split(',');
                Truck truck = new Truck(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), int.Parse(fields[7]), int.Parse(fields[8]));


                if (CheckOfMatchingVehicle(truck))
                {
                    matchingTrucks.Add(truck);
                }
            }

            if (matchingTrucks.Count > 0)
            {
                MenuText.BlueOutput("\nMatching trucks:\n");

                foreach (Truck truck in matchingTrucks)
                {
                    Console.WriteLine("Id: {0}, Brand: {1}, Year: {2}, Model: {3}, Color: {4}, Condition: {5}, Price: {6}, Number of wheels: {7}, loadCapacity: {8}", truck.Id, truck.Brand, truck.Year, truck.Model, truck.Color, truck.Condition, truck.Price, truck.NumberOfWheels, truck.LoadCapacity);
                }
            }
            else
            {
                MenuText.OutputErrorOfNoMatchingVehicle("trucks");
            }

            bool CheckOfMatchingVehicle(Vehicle vehicle)
            {
                string brand = allClients[id - 1].PreferredBrand;
                bool check = false;
                if ((brand == "" || vehicle.Brand == brand)
                 && (yearFrom == 0 || vehicle.Year >= yearFrom)
                 && (yearTo == 0 || vehicle.Year <= yearTo)
                 && (priceFrom == 0 || vehicle.Price >= priceFrom)
                 && (priceTo == 0 || vehicle.Price <= priceTo))
                {
                    check = true;
                }

                return check;
            }
            var methodsForExit = new List<MethodDelegate>();
            methodsForExit.Add(AutomationSearch);
            ExitOrContinueShorter("\n3. Продовжити автоматичний пошук.",methodsForExit);
        }
    }
}