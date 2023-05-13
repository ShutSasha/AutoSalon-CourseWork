using CarDealership.MainFunctions;
using CarDealership.Models;
using ConsoleTables;

namespace CarDealership
{
    public class AutoSalon
    {
        public  List<Vehicle> Vehicles { get; set; }
        public  List<Client> Clients { get; set; }

        public AutoSalon()
        {
            Vehicles = new List<Vehicle>();
            Clients = new List<Client>();
        }
        public void LoadData()
        {
            // Завантаження транспорту з файлу
            AccessFile accessFileToCars = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            if (accessFileToCars != null)
            {
                string[] cars = File.ReadAllLines(accessFileToCars.FilePath!);
                foreach (string car in cars)
                {
                    string[] carInfo = car.Split(',');
                    int id = int.Parse(carInfo[0]);
                    string brand = carInfo[1];
                    int year = int.Parse(carInfo[2]);
                    string model = carInfo[3];
                    string color = carInfo[4];
                    string condition = carInfo[5];
                    int price = int.Parse(carInfo[6]);
                    int doors = int.Parse(carInfo[7]);
                    Car newCar = new Car(id, brand, year, model, color, condition, price, doors);
                    Vehicles.Add(newCar);
                }
            }
            else
            {
                // файл пустий 
            }

            // Завантаження клієнтів з файлу
            AccessFile accessFileToClients = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");
            if (accessFileToClients != null)
            {
                string[] clients = File.ReadAllLines(accessFileToClients.FilePath!);
                foreach (string client in clients)
                {
                    string[] clientInfo = client.Split(',');
                    int id = int.Parse(clientInfo[0]);
                    string name = clientInfo[1];
                    string phone = clientInfo[2];
                    string email = clientInfo[3];
                    string preferredBrand = clientInfo[4];
                    int minPrice = int.Parse(clientInfo[5]);
                    int maxPrice = int.Parse(clientInfo[6]);
                    int minYear = int.Parse(clientInfo[7]);
                    int maxYear = int.Parse(clientInfo[8]);
                    Client newClient = new Client(id, name, phone, email, preferredBrand, minPrice, maxPrice, minYear, maxYear);
                    Clients.Add(newClient);
                }
            }
            else
            {
                //
            }

            AccessFile accessFileToMotorcycle = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");

            if (accessFileToMotorcycle != null)
            {
                string[] bikes = File.ReadAllLines(accessFileToMotorcycle.FilePath!);
                foreach (string bike in bikes)
                {
                    string[] bikeInfo = bike.Split(',');
                    int id = int.Parse(bikeInfo[0]);
                    string brand = bikeInfo[1];
                    int year = int.Parse(bikeInfo[2]);
                    string model = bikeInfo[3];
                    string color = bikeInfo[4];
                    string condition = bikeInfo[5];
                    int price = int.Parse(bikeInfo[6]);
                    string motorcycleType = bikeInfo[7];
                    Motorcycle newBike = new Motorcycle(id, brand, year, model, color, condition, price, motorcycleType);
                    Vehicles.Add(newBike);
                }
            }

            AccessFile accessFileOfTruck = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");

            if (accessFileOfTruck != null)
            {
                string[] trucks = File.ReadAllLines(accessFileOfTruck.FilePath!);
                foreach (string truck in trucks)
                {
                    string[] truckInfo = truck.Split(',');
                    int id = int.Parse(truckInfo[0]);
                    string brand = truckInfo[1];
                    int year = int.Parse(truckInfo[2]);
                    string model = truckInfo[3];
                    string color = truckInfo[4];
                    string condition = truckInfo[5];
                    int price = int.Parse(truckInfo[6]);
                    int numberOfWheels = int.Parse(truckInfo[7]);
                    int loadCapacity = int.Parse(truckInfo[8]);
                    Truck newTruck = new Truck(id, brand, year, model, color, condition, price, numberOfWheels, loadCapacity);
                    Vehicles.Add(newTruck);
                }
            }

        }

        public static void SaveData(AutoSalon salon)
        {
            AccessFile accessFileOfClients = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");

            File.WriteAllText(accessFileOfClients.FilePath!, "");

            using (StreamWriter writer = new StreamWriter(accessFileOfClients.FilePath!))
            {
                
                foreach (Client client in salon.Clients)
                {
                    writer.WriteLine($"{client.Id},{client.Name},{client.Phone},{client.Email},{client.PreferredBrand},{client.MinPrice},{client.MaxPrice},{client.MinYear},{client.MaxYear}");
                }
            }
        }

        public void PrintCars()
        {
            var table = new ConsoleTable("ID", "Brand", "Year", "Model", "Color", "Condition", "Price ($)", "numberOfDoors");

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Car car)
                {
                    Print.AddVehicleToTable(car, table);
                }
            }
            Console.Write(table.ToString());
        }

        public void PrintMotorcycle()
        {
            var table = new ConsoleTable("ID", "Бренд", "Рік випуску", "Модель", "Колір", "Стан", "Ціна ($)", "Тип мотоцикла");

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Motorcycle bike)
                {
                    Print.AddVehicleToTable(bike, table);
                }
            }
            Console.Write(table.ToString());
        }
        public void PrintTruck()
        {
            var table = new ConsoleTable("ID", "Бренд", "Рік випуску", "Модель", "Колір", "Стан", "Ціна ($)", "Кількість коліс", "Вантажопідйомність (т)");

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Truck truck)
                {
                    Print.AddVehicleToTable(truck, table);
                }
            }

            Console.Write(table.ToString());
        }
        public void PrintClients()
        {
            var table = new ConsoleTable("ID", "Ім'я", "Телефон", "Email", "Бажана марка", "Мінімальна ціна ($)", "Максимальна ціна ($)", "Мінімальний рік випуску", "Максимальний рік випуску");

            foreach (Client client in Clients)
            {
                table.AddRow(client.Id, client.Name, client.Phone, client.Email, client.PreferredBrand, client.MinPrice, client.MaxPrice, client.MinYear, client.MaxYear);
            }
            Console.Write(table.ToString());
        }
    }
}