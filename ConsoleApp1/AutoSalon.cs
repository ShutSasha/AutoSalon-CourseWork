using CarDealership.MainFunctions;
using CarDealership.Models;
using CarDealership.Utils;
using CarDealership.ValidatorsMethods;
using ConsoleTables;


namespace CarDealership
{
    public class AutoSalon
    {
        public List<Vehicle> Vehicles { get; set; }
        public List<Client> Clients { get; set; }

        private readonly AccessFile accessFileOfCars = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");

        private readonly AccessFile accessFileOfBikes = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");

        private readonly AccessFile accessFileOfTrucks = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");

        private readonly AccessFile accessFileOfClients = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");

        public AutoSalon()
        {
            Vehicles = new List<Vehicle>();
            Clients = new List<Client>();
        }
        public void LoadData()
        {
            // Завантаження транспорту з файлу

            if (accessFileOfCars != null)
            {
                string[] cars = File.ReadAllLines(accessFileOfCars.FilePath!);
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

            if (accessFileOfClients != null)
            {
                string[] clients = File.ReadAllLines(accessFileOfClients.FilePath!);
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


            if (accessFileOfBikes != null)
            {
                string[] bikes = File.ReadAllLines(accessFileOfBikes.FilePath!);
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


            if (accessFileOfTrucks != null)
            {
                string[] trucks = File.ReadAllLines(accessFileOfTrucks.FilePath!);
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
        public void SaveData()
        {

            //File.WriteAllText(accessFileOfClients.FilePath!, "");
            //File.WriteAllText(accessFileOfCars.FilePath!, "");
            //File.WriteAllText(accessFileOfBikes.FilePath!, "");
            //File.WriteAllText(accessFileOfTruck.FilePath!, "");

            using (StreamWriter writer = new StreamWriter(accessFileOfClients.FilePath!))
            {

                foreach (Client client in Clients)
                {
                    writer.WriteLine($"{client.Id},{client.Name},{client.Phone},{client.Email},{client.PreferredBrand},{client.MinPrice},{client.MaxPrice},{client.MinYear},{client.MaxYear}");
                }
            }
            using (StreamWriter writer = new StreamWriter(accessFileOfCars.FilePath!))
            {
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Car car)
                    {
                        writer.WriteLine($"{car.Id},{car.Brand},{car.Year},{car.Model},{car.Color},{car.Condition},{car.Price},{car.NumberOfDoors}");
                    }

                }
            }
            using (StreamWriter writer = new StreamWriter(accessFileOfBikes.FilePath!))
            {
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Motorcycle motorcycle)
                    {
                        writer.WriteLine($"{motorcycle.Id},{motorcycle.Brand},{motorcycle.Year},{motorcycle.Model},{motorcycle.Color},{motorcycle.Condition},{motorcycle.Price},{motorcycle.MotorcycleType}");
                    }

                }
            }

            using (StreamWriter writer = new StreamWriter(accessFileOfTrucks.FilePath!))
            {
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Truck truck)
                    {
                        writer.WriteLine($"{truck.Id},{truck.Brand},{truck.Year},{truck.Model},{truck.Color},{truck.Condition},{truck.Price},{truck.NumberOfWheels},{truck.LoadCapacity}");
                    }

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
        public void AddCarToList()
        {

            EnterTheCharacteristicsOfTheVehicle(out string brand, out int year, out string model, out string color, out string condition, out int price);

            int numberOfDoors = InputValidators.NumberOfDoorsInputValidator();

            int id = 1;
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Car car)
                {
                    id++;
                }
            }

            Car newCar = new Car(id, brand, year, model, color, condition, price, numberOfDoors);
            Vehicles.Add(newCar);

            MenuText.SuccessOutput("\nCar added successfully!");
        }
        private void EnterTheCharacteristicsOfTheVehicle(out string brand, out int year, out string model, out string color, out string condition, out int price)
        {
            brand = InputValidators.BrandInputValidator();
            year = InputValidators.YearInputOfVehicle();
            model = InputValidators.ModelInputValidator();
            color = InputValidators.ColorInputValidator();
            condition = InputValidators.ConditionInputValidator();
            price = InputValidators.PriceInputValidator();
        }
        private List<Car> ImportCarsFromList()
        {
            List<Car> allCars = new List<Car>();
            foreach (Vehicle vehicle in Vehicles)
            {
                if(vehicle is Car car)
                {     
                    allCars.Add(car);  
                }
            }
            return allCars;

        }
        public void EditInfoAboutCarMethod()
        {
            var allCars = ImportCarsFromList();

            PrintCars();

            int id = IdInputValidator();

            bool checkId = CheckIdExists.CheckIdExistsVehicle(allCars, id);

            if (checkId)
            {
                SelectChangesForCar( id);
            }

            else
            {
                MenuText.ErrorOutputText("\nВи ввели неіснуючий id автомобіля, спробуйте ще раз");
                EditInfoAboutCarMethod();
            }
        }
        private void SelectChangesForCar( int id)
        {
            Console.WriteLine("Оберіть, що ви хочете в ньому змінити\n" + "1. Бренд\n" + "2. Рік\n" + "3. Модель\n" + "4. Колір\n" + "5. Стан автомобіля\n" + "6. Ціна\n" + "7. Кількість дверей автомобіля");

            int selectedNumber = NumberInputValidator();

            if (selectedNumber >= 1 && selectedNumber <= 7)
            {
                string[] fieldNames = { "бренд", "рік", "модель", "колір", "стан автомобіля", "ціна", "кількість дверей" };
                Console.Write($"Значення поля '{fieldNames[selectedNumber - 1]}' буде змінено. ");
                string newValue = "";

                int newInt;
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Car car && car.Id == id)
                    {
                        switch (selectedNumber)
                        {
                            case 1:
                                car.Brand = newValue = InputValidators.BrandInputValidator();
                                break;
                            case 2:
                                newInt = InputValidators.YearInputOfVehicle();
                                car.Year = newInt;
                                newValue = Convert.ToString(newInt);
                                break;
                            case 3:
                                car.Model = newValue = InputValidators.ModelInputValidator();
                                break;
                            case 4:
                                car.Color = newValue = InputValidators.ColorInputValidator();
                                break;
                            case 5:
                                car.Condition = newValue = InputValidators.ConditionInputValidator();
                                break;
                            case 6:
                                newInt = InputValidators.PriceInputValidator();
                                car.Price = newInt;
                                newValue = Convert.ToString(newInt);
                                break;
                            case 7:
                                newInt = InputValidators.NumberOfDoorsInputValidator();
                                car.NumberOfDoors = newInt;
                                newValue = Convert.ToString(newInt);
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine($"Поле '{fieldNames[selectedNumber - 1]}' змінено на '{newValue}'");
                        break;
                    }
                }

            }
            else
            {
                MenuText.ErrorOutputText("Ви ввели неіснуючу функцію, спробуйте ще раз");
                SelectChangesForCar(id);
            }
        }
        public void AddClientToList()
        {
            string? name = InputValidators.FullNameInputValidator();
            string? phone = InputValidators.GetValidPhoneNumber();
            string? email = InputValidators.EmailInputValidator();
            string? preferredBrand = InputValidators.BrandInputValidator();
            int minPrice = InputValidators.PriceInputFromTo("Enter the minimum price: ", 0, 3000000);
            int maxPrice = InputValidators.PriceInputFromTo("Enter the maximum price: ", 1, 3000000);
            if (minPrice > maxPrice)
            {
                (minPrice, maxPrice) = (maxPrice, minPrice);
            }
            int minYear = InputValidators.YearInputFromTo("Enter the minimum year: ", 1920, DateTime.Now.Year);
            int maxYear = InputValidators.YearInputFromTo("Enter the maximum year: ", 1920, DateTime.Now.Year);
            if (minYear > maxYear)
            {
                (minYear, maxYear) = (maxYear, minYear);
            }

            int id = Clients.Count > 0 ? Clients.Max(c => c.Id) + 1 : 1;
            Client newClient = new Client(id, name, phone, email, preferredBrand, minPrice, maxPrice, minYear, maxYear);
            Clients.Add(newClient);

            MenuText.SuccessOutput("\nClient added successfully!");
        }
        private int IdInputValidator()
        {
            while (true)
            {
                Console.Write("\nВведіть id автомобіля: ");
                string input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int id))
                {
                    return id;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Введіть ціле число.");
            }
        }
        private int NumberInputValidator()
        {
            while (true)
            {
                MenuText.OutputEnterNumOfFunc();
                string input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int number))
                {
                    return number;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Введіть ціле число.");
            }
        }
        public void EditInfoAboutClient()
        {

            var allClients = ImportClientsFromFile(accessFileOfClients.Lines!);
            PrintClients();

            Console.Write("\nВведіть id клієнта: ");
            int id = int.Parse(Console.ReadLine()!);

            bool checkId = CheckIdExists.CheckClientExistID(allClients, id);

            if (checkId)
            {
                SelectChangesForClient(accessFileOfClients.Lines!, id, accessFileOfClients.FilePath!);
            }

            else
            {
                Console.WriteLine("\nВи ввели неіснуючий id клієнта, спробуйте ще раз");
                EditInfoAboutClient();
            }
        }
        private List<Client> ImportClientsFromFile(string[] linesClients)
        {
            List<Client> allClients = new List<Client>();

            foreach (string line in linesClients)
            {
                string[] values = line.Split(',');

                int idParse = int.Parse(values[0]);
                string name = values[1];
                string phone = values[2];
                string email = values[3];
                string preferredBrand = values[4];
                int minPrice = int.Parse(values[5]);
                int maxPrice = int.Parse(values[6]);
                int minYear = int.Parse(values[7]);
                int maxYear = int.Parse(values[8]);

                Client newClient = new Client(idParse, name, phone, email, preferredBrand, minPrice, maxPrice, minYear, maxYear);
                allClients.Add(newClient);
            }

            return allClients;
        }
        private void SelectChangesForClient(string[] lines, int id, string filePath)
        {
            Console.WriteLine("Оберіть, що ви хочете в ньому змінити\n" + "1. ПІБ\n" + "2. Телефон\n" + "3. Пошту\n" + "4. Бажаний бренд\n" + "5. Мінімальна ціна\n" + "6. Максимальна ціна\n" + "7. Мінімальний рік випуску\n" +
                "8. Максимальний рік випуску");

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber >= 1 && selectedNumber <= 8)
            {
                string[] fieldNames = { "ПІБ", "Телефон", "Пошта", "Бажаний бренд", "Мінімальна ціна", "Максимальна ціна", "Мінімальний рік випуску", "Максимальний рік випуску" };
                Console.Write($"Введіть знизу нове значення для поля '{fieldNames[selectedNumber - 1]}'\n");
                string newValue = "";

                int newPriceOrYear;
                foreach (Client client in Clients)
                {
                    if (client.Id == id)
                    {
                        switch (selectedNumber)
                        {
                            case 1:
                                client.Name = newValue = InputValidators.FullNameInputValidator();
                                break;
                            case 2:
                                client.Phone = newValue = InputValidators.GetValidPhoneNumber();
                                break;
                            case 3:
                                client.Email = newValue = InputValidators.EmailInputValidator();
                                break;
                            case 4:
                                client.PreferredBrand = newValue = InputValidators.BrandInputValidator();
                                break;
                            case 5:
                                newPriceOrYear = InputValidators.PriceInputValidator();
                                client.MinPrice = newPriceOrYear;
                                newValue = Convert.ToString(newPriceOrYear);
                                break;
                            case 6:
                                newPriceOrYear = InputValidators.PriceInputValidator();
                                client.MaxPrice = newPriceOrYear;
                                newValue = Convert.ToString(newPriceOrYear);
                                break;
                            case 7:
                                newPriceOrYear = InputValidators.YearInputOfVehicle();
                                client.MinYear = newPriceOrYear;
                                newValue = Convert.ToString(newPriceOrYear);
                                break;
                            case 8:
                                newPriceOrYear = InputValidators.YearInputOfVehicle();
                                client.MaxPrice = newPriceOrYear;
                                newValue = Convert.ToString(newPriceOrYear);
                                break;
                            default:
                                break;
                        }
                    }
                }

                Console.WriteLine($"Поле '{fieldNames[selectedNumber - 1]}' змінено на '{newValue}'");

            }
            else
            {
                Console.WriteLine("Ви ввели неіснуючу функцію, спробуйте ще раз");
                SelectChangesForClient(lines, id, filePath);
            }
        }
        public void RemoveClient(StartTheProgram ToMainMenu)
        {
            if(Clients.Count == 0)
            {
                MenuText.ErrorOutputText("\nКлієнтів немає. Список пустий");
                Console.WriteLine("1. До головного меню.\n" +
                    "2. Добавити клієнта");
                Console.Write("Введіть цифру, що хочете зробити далі: ");
                int selectNum = Convert.ToInt32(Console.ReadLine());
                switch (selectNum)
                {
                    case 1:
                        ToMainMenu.Start();
                        break;
                    case 2:
                        AddClientToList();
                        ToMainMenu.Start();
                        break;
                    default:
                        break;
                }
            }

            PrintClients();

            Console.Write("\nВведіть id клієнта, якого хочете видалити: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());

            var clientToRemove = Clients.FirstOrDefault(c => c.Id == idToDelete);
            if (clientToRemove != null)
            {

                Clients.Remove(clientToRemove);

                for (int i = 0; i < Clients.Count; i++)
                {
                    Clients[i].Id = i + 1;
                }
                MenuText.SuccessOutput($"\nКлієнт з айді {idToDelete} успішно видалений з файлу.\n");
            }
            else
            {
                MenuText.ErrorOutputText("Клієнтів немає в списку");
            }
        }
        public void RemoveCar(StartTheProgram ToMainMenu)
        {

            int countCars = 0;
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Car car)
                {
                    countCars++;
                }
            }
            if (countCars == 0)
            {
                MenuText.ErrorOutputText("\nМашин немає. Список порожній.");
                Console.WriteLine("1. До головного меню.\n" +
                    "2. Додати машину.");
                Console.Write("Введіть цифру, що хочете зробити далі: ");
                int selectNum = Convert.ToInt32(Console.ReadLine());
                switch (selectNum)
                {
                    case 1:
                        ToMainMenu.Start();
                        break;
                    case 2:
                        AddCarToList();
                        ToMainMenu.Start();
                        break;
                    default:
                        MenuText.ErrorOutputText("Ввід некоректний. Оберіть 1 або 2.");
                        RemoveBike(ToMainMenu);
                        break;
                }
            }

            PrintCars();

            Console.Write("\nВведіть id машини, яку хочете видалити: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());
            Car carToRemove = null;
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Car car && car.Id == idToDelete)
                {
                    carToRemove = car;
                }
            }

            if (carToRemove != null)
            {
                Vehicles.Remove(carToRemove);

                int newId = 1;
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Car car)
                    {
                        car.Id = newId;
                        newId++;
                    }
                }
                MenuText.SuccessOutput($"\nМашина з айді {idToDelete} успішно видалена з файлу.\n");
            }
            else
            {
                MenuText.ErrorOutputText("Машин немає в списку.");
                ToMainMenu.Start();
            }
        }
        public void RemoveBike(StartTheProgram ToMainMenu)
        {
            int countBikes = 0;
            foreach(Vehicle vehicle in Vehicles)
            {
                if(vehicle is Motorcycle bike)
                {
                    countBikes++;
                }
            }
            if (countBikes == 0)
            {
                MenuText.ErrorOutputText("\nМотоциклів немає. Список порожній.");
                Console.WriteLine("1. До головного меню.\n" +
                    "2. Додати мотоцикл.");
                Console.Write("Введіть цифру, що хочете зробити далі: ");
                int selectNum = Convert.ToInt32(Console.ReadLine());
                switch (selectNum)
                {
                    case 1:
                        ToMainMenu.Start();
                        break;
                    case 2:
                        AddMotorcycleToList();
                        ToMainMenu.Start();
                        break;
                    default:
                        MenuText.ErrorOutputText("Ввід некоректний. Оберіть 1 або 2.");
                        RemoveBike(ToMainMenu);
                        break;
                }
            }

            PrintMotorcycle();

            Console.Write("\nВведіть id мотоцикла, який хочете видалити: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());
            Motorcycle bikeToRemove = Vehicles.FirstOrDefault(vehicle => vehicle is Motorcycle bike && bike.Id == idToDelete) as Motorcycle;

            if (bikeToRemove != null)
            {
                Vehicles.Remove(bikeToRemove);

                int newId = 1;
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Motorcycle bike)
                    {
                        bike.Id = newId;
                        newId++;
                    }
                }

                MenuText.SuccessOutput($"\nМотоцикл з айді {idToDelete} успішно видалений з файлу.\n");
            }
            else
            {
                MenuText.ErrorOutputText("Мотоцикла немає в списку.");
                ToMainMenu.Start();
            }
        }
        public void RemoveTruck(StartTheProgram ToMainMenu)
        {
            int countTrucks = 0;
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Truck truck)
                {
                    countTrucks++;
                }
            }

            if (countTrucks == 0)
            {
                MenuText.ErrorOutputText("\nГрузовиків немає. Список порожній.");
                Console.WriteLine("1. До головного меню.\n" +
                    "2. Додати грузовик.");
                Console.Write("Введіть цифру, що хочете зробити далі: ");
                int selectNum = Convert.ToInt32(Console.ReadLine());
                switch (selectNum)
                {
                    case 1:
                        ToMainMenu.Start();
                        break;
                    case 2:
                        AddTruckToList();
                        ToMainMenu.Start();
                        break;
                    default:
                        MenuText.ErrorOutputText("Ввід некоректний. Оберіть 1 або 2.");
                        RemoveTruck(ToMainMenu);
                        break;
                }
            }

            PrintTruck();

            Console.Write("\nВведіть id грузовика, який хочете видалити: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());
            Truck truckToRemove = Vehicles.FirstOrDefault(vehicle => vehicle is Truck truck && truck.Id == idToDelete) as Truck;

            if (truckToRemove != null)
            {
                Vehicles.Remove(truckToRemove);

                int newId = 1;
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Truck truck)
                    {
                        truck.Id = newId;
                        newId++;
                    }
                }

                MenuText.SuccessOutput($"\nГрузовик з айді {idToDelete} успішно видалений з файлу.\n");
            }
            else
            {
                MenuText.ErrorOutputText("Грузовика немає в списку.");
                ToMainMenu.Start();
            }
        }
        public void AddMotorcycleToList()
        {

            InputValidators.EnterTheCharacteristicsOfTheVehicle(out string brand, out int year, out string model, out string color, out string condition, out int price);

            Console.Write("Введіть тип мотоцикла(sport, cruiser): ");
            string motorcycleType = InputValidators.BikeType();


            int id = 1;
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Motorcycle bike)
                {
                    id++;
                }
            }

            Motorcycle newBike = new Motorcycle(id, brand, year, model, color, condition, price, motorcycleType);
            Vehicles.Add(newBike);

            MenuText.SuccessOutput("\nMotorcycle added successfully!");
        }
        public void AddTruckToList()
        {

            InputValidators.EnterTheCharacteristicsOfTheVehicle(out string brand, out int year, out string model, out string color, out string condition, out int price);

            int numberOfWheels = InputValidators.NumberOfWheelsInputValidator();

            int loadCapacity = InputValidators.LoadCapacityInputValidator();

            int id = 1;
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Truck truck)
                {
                    id++;
                }
            }

            Truck newTruck = new Truck(id, brand, year, model, color, condition, price, numberOfWheels, loadCapacity);
            Vehicles.Add(newTruck);

            MenuText.SuccessOutput("\nTruck added successfully!");
        }
        private List<Motorcycle> ImportBikesFromList()
        {
            List<Motorcycle> allBikes = new List<Motorcycle>();
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Motorcycle bike)
                {
                    allBikes.Add(bike);
                }
            }
            return allBikes;

        }
        public void EditInfoAboutBikes()
        {
            List<Motorcycle> allBikes = ImportBikesFromList();

            PrintMotorcycle();

            int id = IdInputValidator();

            bool checkId = CheckIdExists.CheckIdExistsVehicle(allBikes, id);

            if (checkId)
            {
                SelectChangesForBike(id);
            }

            else
            {
                MenuText.ErrorOutputText("\nВи ввели неіснуючий id мотоцикла, спробуйте ще раз");
                EditInfoAboutBikes();
            }
        }
        private void SelectChangesForBike(int id)
        {
            Console.WriteLine("Оберіть, що ви хочете змінити:\n" +
                   "1. Бренд\n" +
                   "2. Рік\n" +
                   "3. Модель\n" +
                   "4. Колір\n" +
                   "5. Стан мотоцикла\n" +
                   "6. Ціна\n" +
                   "7. Тип мотоцикла");

            int selectedNumber = NumberInputValidator();

            if (selectedNumber >= 1 && selectedNumber <= 7)
            {
                string[] fieldNames = { "Бренд", "Рік", "Модель", "Колір", "Стан мотоцикла", "Ціна", "Тип мотоцикла" };
                Console.Write($"Значення поля '{fieldNames[selectedNumber - 1]}' буде змінено. ");
                string newValue = "";

                int newInt;
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Motorcycle bike && bike.Id == id)
                    {
                        switch (selectedNumber)
                        {
                            case 1:
                                bike.Brand = newValue = InputValidators.BrandInputValidator();
                                break;
                            case 2:
                                newInt = InputValidators.YearInputOfVehicle();
                                bike.Year = newInt;
                                newValue = Convert.ToString(newInt);
                                break;
                            case 3:
                                bike.Model = newValue = InputValidators.ModelInputValidator();
                                break;
                            case 4:
                                bike.Color = newValue = InputValidators.ColorInputValidator();
                                break;
                            case 5:
                                bike.Condition = newValue = InputValidators.ConditionInputValidator();
                                break;
                            case 6:
                                newInt = InputValidators.PriceInputValidator();
                                bike.Price = newInt;
                                newValue = Convert.ToString(newInt);
                                break;
                            case 7:
                                bike.MotorcycleType = newValue = InputValidators.BikeType();
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine($"Поле '{fieldNames[selectedNumber - 1]}' змінено на '{newValue}'");
                        break;
                    }
                }

            }
            else
            {
                MenuText.ErrorOutputText("Ви ввели неіснуючу функцію, спробуйте ще раз");
                SelectChangesForBike(id);
            }
        }
        private List<Truck> ImportTrucksFromList()
        {
            List<Truck> allTrucks = new List<Truck>();
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Truck truck)
                {
                    allTrucks.Add(truck);
                }
            }
            return allTrucks;

        }
        public void EditInfoAboutTrucks()
        {
            List<Truck> allTrucks = ImportTrucksFromList();

           PrintTruck();

            int id = IdInputValidator();

            bool checkId = CheckIdExists.CheckIdExistsVehicle(allTrucks, id);

            if (checkId)
            {
                SelectChangesForTruck(id);
            }

            else
            {
                MenuText.ErrorOutputText("\nВи ввели неіснуючий id мотоцикла, спробуйте ще раз");
                EditInfoAboutTrucks();
            }
        }
        private void SelectChangesForTruck(int id)
        {
            Console.WriteLine("Оберіть, що ви хочете змінити:\n" +
                   "1. Бренд\n" +
                   "2. Рік\n" +
                   "3. Модель\n" +
                   "4. Колір\n" +
                   "5. Стан грузовика\n" +
                   "6. Ціна\n" +
                   "7. Кількість колес\n" +
                   "8. Вантажопідйомність (т)");


            int selectedNumber = NumberInputValidator();

            if (selectedNumber >= 1 && selectedNumber <= 8)
            {
                string[] fieldNames = { "Бренд", "Рік", "Модель", "Колір", "Стан грузовика", "Ціна", "Кількість колес", "Вантажопідйомність(т)" };
                Console.Write($"Значення поля '{fieldNames[selectedNumber - 1]}' буде змінено. ");
                string newValue = "";

                int newInt;
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Truck truck && truck.Id == id)
                    {
                        switch (selectedNumber)
                        {
                            case 1:
                                truck.Brand = newValue = InputValidators.BrandInputValidator();
                                break;
                            case 2:
                                newInt = InputValidators.YearInputOfVehicle();
                                truck.Year = newInt;
                                newValue = Convert.ToString(newInt);
                                break;
                            case 3:
                                truck.Model = newValue = InputValidators.ModelInputValidator();
                                break;
                            case 4:
                                truck.Color = newValue = InputValidators.ColorInputValidator();
                                break;
                            case 5:
                                truck.Condition = newValue = InputValidators.ConditionInputValidator();
                                break;
                            case 6:
                                newInt = InputValidators.PriceInputValidator();
                                truck.Price = newInt;
                                newValue = Convert.ToString(newInt);
                                break;
                            case 7:
                                newInt = InputValidators.NumberOfWheelsInputValidator();
                                truck.NumberOfWheels = newInt;
                                newValue = Convert.ToString(newInt);
                                break;
                            case 8:
                                newInt = InputValidators.LoadCapacityInputValidator();
                                truck.LoadCapacity = newInt;
                                newValue = Convert.ToString(newInt);
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine($"Поле '{fieldNames[selectedNumber - 1]}' змінено на '{newValue}'");
                        break;
                    }
                }

            }
            else
            {
                MenuText.ErrorOutputText("Ви ввели неіснуючу функцію, спробуйте ще раз");
                SelectChangesForTruck(id);
            }
        }
    }
}