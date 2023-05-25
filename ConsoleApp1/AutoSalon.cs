using CarDealership.SecondaryFunctions;
using CarDealership.Models;
using CarDealership.Utils;
using CarDealership.ValidatorsMethods;
using ConsoleTables;
using static CarDealership.SecondaryFunctions.ExitOrContinue;

namespace CarDealership
{
    public class AutoSalon
    {
        public List<Vehicle> Vehicles { get; set; }
        public List<Client> Clients { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Carrier> Carriers { get; set; }
        public List<Receipt> Receipts  { get; set; }

        private readonly AccessFile accessFileOfCars = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\DB");

        private readonly AccessFile accessFileOfBikes = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\DB");

        private readonly AccessFile accessFileOfTrucks = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\DB");

        private readonly AccessFile accessFileOfClients = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\DB");

        private readonly AccessFile accessFileOfSuppliers = AccessFile.GetAccessToFile("Supplier.txt", "..\\..\\..\\DB");

        private readonly AccessFile accessFileOfCarriers = AccessFile.GetAccessToFile("Carrier.txt", "..\\..\\..\\DB");

        private readonly AccessFile accessFileOfReceipt = AccessFile.GetAccessToFile("Receipt.txt", "..\\..\\..\\DB");

        private readonly AccessFile accessFileOfReceiptForClient = AccessFile.GetAccessToFile("ReceiptForClient.txt", "..\\..\\..\\DB");

        public AutoSalon()
        {
            Vehicles = new List<Vehicle>();
            Clients = new List<Client>();
            Suppliers = new List<Supplier>();
            Carriers = new List<Carrier>();
            Receipts = new List<Receipt>();
        }
        public void LoadData()
        {
            
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

            if (accessFileOfSuppliers != null)
            {
                string[] suppliers = File.ReadAllLines(accessFileOfSuppliers.FilePath!);
                foreach (string supplier in suppliers)
                {
                    string[] supplierInfo = supplier.Split(',');
                    int id = int.Parse(supplierInfo[0]);
                    string name = supplierInfo[1];
                    int price = int.Parse(supplierInfo[2]);
                    Supplier newSupplier = new Supplier(id, name, price);
                    Suppliers.Add(newSupplier);
                }
            }

            if (accessFileOfCarriers != null)
            {
                string[] carriers = File.ReadAllLines(accessFileOfCarriers.FilePath!);
                foreach (string carrier in carriers)
                {
                    string[] carrierInfo = carrier.Split(',');
                    int id = int.Parse(carrierInfo[0]);
                    string name = carrierInfo[1];
                    int price = int.Parse(carrierInfo[2]);
                    string speedDescription = carrierInfo[3];
                    Carrier newСarrier = new Carrier(id, name, price, speedDescription);
                    Carriers.Add(newСarrier);
                }
            }
            if (accessFileOfReceipt != null)
            {
                string[] receipts = File.ReadAllLines(accessFileOfReceipt.FilePath!);
                foreach (string receipt in receipts)
                {
                    string[] receiptInfo = receipt.Split(',');
                    string clientName = receiptInfo[0];
                    string clientEmail = receiptInfo[1];
                    string clientPhone = receiptInfo[2];
                    int vehiclePrice = int.Parse(receiptInfo[3]);
                    string vehicleBrand = receiptInfo[4];
                    string vehicleModel = receiptInfo[5];
                    string vehicleColor = receiptInfo[6];
                    string supplierName = receiptInfo[7];
                    int supplierPrice = int.Parse(receiptInfo[8]);
                    string carrierName = receiptInfo[9];
                    int carrierPrice = int.Parse(receiptInfo[10]);
                    int totalPrice = int.Parse(receiptInfo[11]);
                    DateTime purchaseDate = DateTime.Parse(receiptInfo[12]);
                    Receipt newReceipt = new Receipt(clientName, clientEmail, clientPhone, vehiclePrice, vehicleBrand, vehicleModel, vehicleColor, supplierName, supplierPrice, carrierName, carrierPrice, totalPrice, purchaseDate);
                    Receipts.Add(newReceipt);
                }
            }

        }
        public void SaveData()
        {

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

            using (StreamWriter writer = new StreamWriter(accessFileOfReceipt.FilePath!))
            {
                foreach (Receipt receipt in Receipts)
                {
                    writer.WriteLine($"{receipt.ClientName},{receipt.ClientEmail},{receipt.ClientPhone},{receipt.VehiclePrice},{receipt.VehicleBrand},{receipt.VehicleModel},{receipt.VehicleColor},{receipt.SupplierName},{receipt.SupplierPrice},{receipt.CarrierName},{receipt.CarrierPrice},{receipt.TotalPrice},{receipt.PurchaseDate}");
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
        public void PrintSuppliers()
        {
            var table = new ConsoleTable("ID", "Постачальник", "Ціна");

            foreach (Supplier supplier in Suppliers)
            {
                table.AddRow(supplier.Id, supplier.Name, supplier.Price);
            }
            Console.Write(table.ToString());
        }
        public void PrintCarriers()
        {
            var table = new ConsoleTable("ID", "Перевізник", "Ціна", "Швидкість");

            foreach (Carrier carrier in Carriers)
            {
                table.AddRow(carrier.Id, carrier.Name, carrier.Price, carrier.SpeedDescription);
            }
            Console.Write(table.ToString());
        }
        public void PrintReceipts()
        {
            var table = new ConsoleTable(
                "Ім'я клієнта",
                "Електронна пошта",
                "Телефон",
                "Ціна транспорту ($)",
                "Бренд транспорту",
                "Модель транспорту",
                "Колір транспорту",
                "Постачальник",
                "Ціна постачальника ($)",
                "Перевізник",
                "Ціна перевізника ($)",
                "Загальна ціна ($)",
                "Дата покупки"
            );

            foreach (Receipt receipt in Receipts)
            {
                table.AddRow(
                    receipt.ClientName,
                    receipt.ClientEmail,
                    receipt.ClientPhone,
                    receipt.VehiclePrice,
                    receipt.VehicleBrand,
                    receipt.VehicleModel,
                    receipt.VehicleColor,
                    receipt.SupplierName,
                    receipt.SupplierPrice,
                    receipt.CarrierName,
                    receipt.CarrierPrice,
                    receipt.TotalPrice,
                    receipt.PurchaseDate.ToString("yyyy-MM-dd HH:mm:ss")
                );
            }

            Console.WriteLine("\nСписок чеків:");
            Console.WriteLine(table.ToString());
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
                if (vehicle is Car car)
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
                SelectChangesForCar(id);
            }

            else
            {
                MenuText.ErrorOutputText("\nВи ввели неіснуючий id автомобіля, спробуйте ще раз");
                EditInfoAboutCarMethod();
            }
        }
        private void SelectChangesForCar(int id)
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
                string input = Console.ReadLine()?.Trim()!;
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
                string input = Console.ReadLine()?.Trim()!;
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int number))
                {
                    return number;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Введіть ціле число.");
            }
        }
        public void EditInfoAboutClient()
        {


            PrintClients();

            Console.Write("\nВведіть id клієнта: ");
            int id = int.Parse(Console.ReadLine()!);

            bool checkId = CheckIdExists.CheckClientExistID(Clients, id);

            if (checkId)
            {
                SelectChangesForClient(id);
            }

            else
            {
                Console.WriteLine("\nВи ввели неіснуючий id клієнта, спробуйте ще раз");
                EditInfoAboutClient();
            }
        }
        private void SelectChangesForClient(int id)
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
                SelectChangesForClient(id);
            }
        }
        public void RemoveClient(StartTheProgram ToMainMenu)
        {
            if (Clients.Count == 0)
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
            Car carToRemove = null!;
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
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Motorcycle bike)
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
        public void AutomationSearch(StartTheProgram toMainMenu)
        {
            if (Clients.Count == 0)
            {
                MenuText.ErrorOutputText("Клієнтів немає. Введіть 1 для додавання нового клієнта або 2 для виходу до головного меню.");

                bool validInput = false;
                int selectedNum;

                while (!validInput)
                {
                    Console.Write("Введіть тут цифру:");
                    string input = Console.ReadKey().KeyChar.ToString();
                    validInput = int.TryParse(input, out selectedNum);
                    Console.WriteLine();

                    if (validInput)
                    {
                        switch (selectedNum)
                        {
                            case 1:
                                AddClientToList();
                                break;
                            case 2:
                                toMainMenu.Start();
                                break;
                            default:
                                MenuText.ErrorOutputText("Не правильно введене значення, спробуйте ще раз.");
                                validInput = false;
                                break;
                        }
                    }
                    else
                    {
                        MenuText.ErrorOutputText("Не правильно введене значення, спробуйте ще раз.");
                    }
                }
            }

            PrintClients();

            int id = ValidateIdInput(Clients);


            int priceFrom = Clients[id - 1].MinPrice;
            int priceTo = Clients[id - 1].MaxPrice;
            int yearFrom = Clients[id - 1].MinYear;
            int yearTo = Clients[id - 1].MaxYear;


            List<Car> matchingCars = new List<Car>();
            matchingCars = FindMatchCars(matchingCars, yearFrom, yearTo, priceFrom, priceTo, id);

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


            List<Motorcycle> matchingBikes = new List<Motorcycle>();
            matchingBikes = FindMatchBikes(matchingBikes, yearFrom, yearTo, priceFrom, priceTo, id);


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


            List<Truck> matchingTrucks = new List<Truck>();
            matchingTrucks = FindMatchTrucks(matchingTrucks, yearFrom, yearTo, priceFrom, priceTo, id);

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


            var methodsForExit = new List<MethodDelegate>();
            methodsForExit.Add(() => AutomationSearch(toMainMenu));
            methodsForExit.Add(() => PlaceOrder(toMainMenu));
            ExitOrContinueShorter(this, "\n3. Продовжити автоматичний пошук.\n4. Зробити замовлення.", methodsForExit);
        }
        private bool CheckOfMatchingVehicle(Vehicle vehicle, int yearFrom, int yearTo, int priceFrom, int priceTo, int id)
        {
            string brand = Clients[id - 1].PreferredBrand;
            bool check = false;
            if ((brand == "" || vehicle.Brand.ToLower() == brand.ToLower())
             && (yearFrom == 0 || vehicle.Year >= yearFrom)
             && (yearTo == 0 || vehicle.Year <= yearTo)
             && (priceFrom == 0 || vehicle.Price >= priceFrom)
             && (priceTo == 0 || vehicle.Price <= priceTo))
            {
                check = true;
            }

            return check;
        }
        private List<Car> FindMatchCars(List<Car> matchingCars, int yearFrom, int yearTo, int priceFrom, int priceTo, int id)
        {
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Car car && CheckOfMatchingVehicle(car, yearFrom, yearTo, priceFrom, priceTo, id))
                {
                    matchingCars.Add(car);
                }
            }
            return matchingCars;
        }
        private List<Motorcycle> FindMatchBikes(List<Motorcycle> matchingBikes, int yearFrom, int yearTo, int priceFrom, int priceTo, int id)
        {
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Motorcycle bike && CheckOfMatchingVehicle(bike, yearFrom, yearTo, priceFrom, priceTo, id))
                {
                    matchingBikes.Add(bike);
                }
            }
            return matchingBikes;
        }
        private List<Truck> FindMatchTrucks(List<Truck> matchingTrucks, int yearFrom, int yearTo, int priceFrom, int priceTo, int id)
        {
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Truck truck && CheckOfMatchingVehicle(truck, yearFrom, yearTo, priceFrom, priceTo, id))
                {
                    matchingTrucks.Add(truck);
                }
            }
            return matchingTrucks;
        }
        private static int ValidateIdInput(List<Client> clients)
        {
            while (true)
            {
                Console.Write("\nВиберіть id клієнта для якого хочете зробити автоматичний підбір транспорту: ");
                string input = Console.ReadLine()!;
                if (!int.TryParse(input, out int id) || id <= 0)
                {
                    MenuText.ErrorOutputText("Неправильний ввід. Введіть додатнє ціле число.");
                }
                else
                {
                    bool idExists = false;
                    foreach (Client client in clients)
                    {
                        string data = Convert.ToString(client.Id);
                        if (data == input)
                        {
                            idExists = true;
                            break;
                        }
                    }
                    if (idExists)
                    {
                        return id;
                    }
                    else
                    {
                        MenuText.ErrorOutputText("Неправильно обраний id, спробуйте ще раз.");
                    }
                }
            }
        }
        public void SearchMethod()
        {

            List<Car> matchingCars = new List<Car>();
            List<Motorcycle> matchingBikes = new List<Motorcycle>();
            List<Truck> matchingTrucks = new List<Truck>();

            string brand = InputValidators.BrandInputValidator(true);

            int yearFrom = InputValidators.YearInputFromTo("Enter the year from: ", 1920, DateTime.Now.Year, true);

            int yearTo = InputValidators.YearInputFromTo("Enter the year To: ", 1920, DateTime.Now.Year, true);
            if (yearFrom > yearTo) (yearFrom, yearTo) = (yearTo, yearFrom);

            string model = InputValidators.ModelInputValidator(true);

            string color = InputValidators.ColorInputValidator(true);

            string condition = InputValidators.ConditionInputValidator(true);

            int priceFrom = InputValidators.PriceInputFromTo("Enter the price from: ", 0, 3000000, true);

            int priceTo = InputValidators.PriceInputFromTo("Enter the price to: ", 1, 3000000, true);
            if (priceFrom > priceTo) (priceFrom, priceTo) = (priceTo, priceFrom);

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Car car && CheckOfMatchingVehicle(car))
                {
                    matchingCars.Add(car);
                }
            }

            Print.PrintMatchingVehicle(matchingCars.ConvertAll(list => (Vehicle)list), "cars", MenuText.carHeader);

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Motorcycle bike && CheckOfMatchingVehicle(bike))
                {
                    matchingBikes.Add(bike);
                }
            }

            Print.PrintMatchingVehicle(matchingBikes.ConvertAll(list => (Vehicle)list), "bikes", MenuText.bikeHeader);

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle is Truck truck && CheckOfMatchingVehicle(truck))
                {
                    matchingTrucks.Add(truck);
                }
            }

            Print.PrintMatchingVehicle(matchingTrucks.ConvertAll(list => (Vehicle)list), "trucks", MenuText.truckHeader);

            bool CheckOfMatchingVehicle(Vehicle vehicle)
            {
                bool check = false;
                if ((brand == "" || vehicle.Brand.ToLower() == brand.ToLower())
                 && (yearFrom == 0 || yearFrom == -1 || vehicle.Year >= yearFrom)
                 && (yearTo == 0 || yearTo == -1 || vehicle.Year <= yearTo)
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
        }
        public void PlaceOrder(StartTheProgram toMainMenu)
        {
            Console.WriteLine("Список клієнтів:");

            PrintClients();
            Client selectedClient = ChooseClientForOrder(toMainMenu);
            Vehicle selectedVehicle = ChooseVehicleForOrder();
            Supplier selectedSupplier = ChooseSupplierForOrder();
            Carrier selectedCarrier = ChooseCarrierForOrder();
            CreateReceipt(selectedClient, selectedVehicle, selectedSupplier, selectedCarrier);

        }
        private Client ChooseClientForOrder(StartTheProgram toMainMenu)
        {
            if (Clients.Count < 1)
            {
                MenuText.ErrorOutputText("\nКлієнтів немає. Обиріть наступну функцію -> 1. Вийти до головного меню. 2. Додати клієнта до списку.");
                MenuText.BlueOutput("Оберіть цифру: ");
                int selectedAction;
                bool isValidSelectedAction = int.TryParse(Console.ReadLine(), out selectedAction);
                if (isValidSelectedAction)
                {
                    switch (selectedAction)
                    {
                        case 1:
                            toMainMenu.Start();
                            break;
                        case 2:
                            AddClientToList();
                            break;
                        default:
                            return ChooseClientForOrder(toMainMenu); 
                    }
                }
                else
                {
                    return ChooseClientForOrder(toMainMenu); 
                }
            }

            Console.Write("\nВиберіть ID клієнта: ");
            int clientId;
            bool isValidClientId = int.TryParse(Console.ReadLine(), out clientId);

            if (!isValidClientId || (clientId <= 0 || clientId > Clients.Count))
            {
                MenuText.ErrorOutputText("Некоректний ID клієнта. Будь ласка, введіть ціле число або правильний id клієнта.");
                return ChooseClientForOrder(toMainMenu); 
            }

            var selectedClient = Clients.FirstOrDefault(c => c.Id == clientId);

            return selectedClient;
        }
        private Vehicle ChooseVehicleForOrder()
        {
            Console.WriteLine("\nОберіть тип транспорту:\n" +
                     "1. Машина\n" +
                     "2. Мотоцикл\n" +
                     "3. Грузовик");

            Console.Write("Введіть номер варіанту: ");
            int transportType;
            bool isValidTransportType = int.TryParse(Console.ReadLine(), out transportType);

            if (!isValidTransportType || transportType < 1 || transportType > 3)
            {
                MenuText.ErrorOutputText("Некоректний варіант транспорту. Будь ласка, введіть ціле число від 1 до 3.");
                return ChooseVehicleForOrder();
            }

            Type selectedVehicleType;
            switch (transportType)
            {
                case 1:
                    PrintCars();
                    selectedVehicleType = typeof(Car);
                    break;
                case 2:
                    PrintMotorcycle();
                    selectedVehicleType = typeof(Motorcycle);
                    break;
                case 3:
                    PrintTruck();
                    selectedVehicleType = typeof(Truck);
                    break;
                default:
                    selectedVehicleType = null;
                    break;
            }

            if (selectedVehicleType == null)
            {
                MenuText.ErrorOutputText("Некоректний варіант транспорту.");
                return ChooseVehicleForOrder();
            }

            Console.Write("\nВиберіть ID транспортного засобу: ");
            int vehicleId;
            bool isValidVehicleId = int.TryParse(Console.ReadLine(), out vehicleId);

            if (!isValidVehicleId)
            {
                MenuText.ErrorOutputText("Некоректний ID транспортного засобу. Будь ласка, введіть ціле число.");
                return ChooseVehicleForOrder();
            }

            var selectedVehicle = Vehicles.FirstOrDefault(v => v.Id == vehicleId && v.GetType() == selectedVehicleType);

            if (selectedVehicle == null)
            {
                MenuText.ErrorOutputText("Транспортний засіб з вказаним ID не знайдено.");
                return ChooseVehicleForOrder();
            }

            return selectedVehicle;
        }
        private Supplier ChooseSupplierForOrder()
        {
            Console.WriteLine("\nОберіть постачальника:");

            PrintSuppliers();

            Console.Write("Введіть ID постачальника: ");
            int supplierId;
            bool isValidSupplierId = int.TryParse(Console.ReadLine(), out supplierId);

            if (!isValidSupplierId || supplierId <= 0 || supplierId > Suppliers.Count)
            {
                MenuText.ErrorOutputText("Некоректний ID постачальника. Будь ласка, введіть ціле число.");
                return ChooseSupplierForOrder();
            }

            var selectedSupplier = Suppliers.FirstOrDefault(s => s.Id == supplierId);

            if (selectedSupplier == null)
            {
                MenuText.ErrorOutputText("Постачальник з вказаним ID не знайдений. Будь ласка, виберіть існуючого постачальника.");
                return ChooseSupplierForOrder();
            }

            return selectedSupplier;
        }
        private Carrier ChooseCarrierForOrder()
        {
            Console.WriteLine("\nОберіть перевізника:");

            PrintCarriers();

            Console.Write("\nВведіть ID перевізника: ");
            int carrierId;
            bool isValidCarrierId = int.TryParse(Console.ReadLine(), out carrierId);

            if (!isValidCarrierId || carrierId <= 0 || carrierId > Carriers.Count)
            {
                MenuText.ErrorOutputText("Некоректний ID перевізника. Будь ласка, введіть ціле число.");
                return ChooseCarrierForOrder();
            }

            var selectedCarrier = Carriers.FirstOrDefault(c => c.Id == carrierId);

            if (selectedCarrier == null)
            {
                MenuText.ErrorOutputText("Перевізник з вказаним ID не знайдений. Будь ласка, виберіть існуючого перевізника.");
                return ChooseCarrierForOrder();
            }

            return selectedCarrier;
        }
        private void CreateReceipt(Client client, Vehicle vehicle, Supplier supplier, Carrier carrier)
        {
            Receipt receipt = new Receipt(
                client.Name,
                client.Email,
                client.Phone,
                vehicle.Price,
                vehicle.Brand,
                vehicle.Model,
                vehicle.Color,
                supplier.Name,
                supplier.Price,
                carrier.Name,
                carrier.Price,
                vehicle.Price + supplier.Price + carrier.Price,
                DateTime.Now
            );

            using (StreamWriter writer = new StreamWriter(accessFileOfReceiptForClient.FilePath!, true))
            {
                writer.WriteLine("---------- Receipt ----------");
                writer.WriteLine($"Date: {DateTime.Now}");
                writer.WriteLine();

                writer.WriteLine("Client Information:");
                writer.WriteLine($"Name: {client.Name}");
                writer.WriteLine($"Email: {client.Email}");
                writer.WriteLine($"Phone: {client.Phone}");
                writer.WriteLine();

                writer.WriteLine("Vehicle Information:");
                writer.WriteLine($"Brand: {vehicle.Brand}");
                writer.WriteLine($"Model: {vehicle.Model}");
                writer.WriteLine($"Color: {vehicle.Color}");
                writer.WriteLine($"Price: ${vehicle.Price}");
                writer.WriteLine();

                writer.WriteLine("Supplier Information:");
                writer.WriteLine($"Name: {supplier.Name}");
                writer.WriteLine($"Price: ${supplier.Price}");
                writer.WriteLine();

                writer.WriteLine("Carrier Information:");
                writer.WriteLine($"Name: {carrier.Name}");
                writer.WriteLine($"Price: ${carrier.Price}");
                writer.WriteLine();

                writer.WriteLine($"Total Price: ${vehicle.Price + supplier.Price + carrier.Price}");
                writer.WriteLine();

                writer.WriteLine("-------------------------------");
            }

            Receipts.Add(receipt);
            Vehicles.Remove(vehicle);
            Clients.Remove(client);

            for (int i = 0; i < Clients.Count; i++)
            {
                Clients[i].Id = i + 1;
            }

            int newIdForCar = 1;
            foreach (Vehicle v in Vehicles)
            {
                if (v is Car car)
                {
                    car.Id = newIdForCar;
                    newIdForCar++;
                }
            }

            int newIdForMotorcycle = 1;
            foreach (Vehicle v in Vehicles)
            {
                if (v is Motorcycle motorcycle)
                {
                    motorcycle.Id = newIdForMotorcycle;
                    newIdForMotorcycle++;
                }
            }

            int newIdForTruck = 1;
            foreach (Vehicle v in Vehicles)
            {
                if (v is Truck truck)
                {
                    truck.Id = newIdForTruck;
                    newIdForTruck++;
                }
            }

            Console.WriteLine("\nЧек на покупку створений та збережений.");
        }
    }
}
