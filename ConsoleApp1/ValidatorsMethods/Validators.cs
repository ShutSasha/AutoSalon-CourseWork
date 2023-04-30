using CarDealership.MainFunctions;
using CarDealership.MainFunctions.CarFunctions;
using CarDealership.MainFunctions.ClientFunctions;
using CarDealership.MainFunctions.MotorcycleFunctions;
using CarDealership.MainFunctions.TruckFunctions;
using System.Text.RegularExpressions;
using static CarDealership.MainFunctions.ExitOrContinue;

namespace CarDealership.ValidatorsMethods
{
    internal class Validators
    {

        public static string EmailInputValidator()
        {
            string email;
            while (true)
            {
                Console.Write("Введіть електронну пошту: ");
                 email = Console.ReadLine();

                if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return email;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неправильний формат електронної пошти. Будь ласка, спробуйте ще раз.");
                Console.ResetColor();
            }
            
        }
        public static string ValidatePhoneNumber()
        {
            string phoneNumber;
            while (true)
            {
                Console.Write("Введіть номер телефону строго за форматом (+380 ХХ ХХХХХХХ): ");
                phoneNumber = Console.ReadLine();

                // Видаляємо всі пробіли
                phoneNumber = phoneNumber.Replace(" ", string.Empty);

                // Перевірка на довжину номеру
                if (phoneNumber.Length != 13)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неправильний номер телефону. Номер повинен мати 12 цифр.");
                    Console.ResetColor();
                    continue;
                }

                // Перевірка чи починається номер з +380
                if (!phoneNumber.StartsWith("+380"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неправильний номер телефону. Номер повинен починатися з +380.");
                    Console.ResetColor();
                    continue;
                }

                // Перевірка, щоб всі решта символів були цифрами
                if (!phoneNumber.Substring(1).All(char.IsDigit))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неправильний номер телефону. Номер повинен містити тільки цифри.");
                    Console.ResetColor();
                    continue;
                }

                // Якщо номер пройшов всі перевірки, повертаємо його
                return phoneNumber;
            }
        }

        public static int YearInputOfVehicle()
        {
            int year;
            while (true)
            {
                Console.Write("Введіть рік випуску(1920-нині): ");
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    if (year >= 1920 && year <= DateTime.Now.Year)
                    {
                        return year; // якщо рік в межах 1920 - поточний рік, то повертаємо його
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неправильний рік випуску. Будь ласка, спробуйте ще раз.");
                Console.ResetColor();
            }
        }
        public static int FindMaxNumberInString(string input)
        {
            List<int> numbers = new List<int>();
            string[] words = input.Split(' ', '\n', '\r', '.', ',', ':', '\t');

            foreach (string word in words)
            {
                int number;
                if (int.TryParse(word, out number))
                {
                    if (number == -1)
                    {
                        continue;
                    }
                    numbers.Add(number);
                }
            }

            if (numbers.Count == 0)
            {
                throw new Exception("No numbers found in input string.");
            }

            return numbers.Max();
        }

        public static void ValidatorInputValue(int inputNumber, int maxNumberInInput)
        {

            if (inputNumber > maxNumberInInput || inputNumber < 1 && inputNumber != -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введене значення не валідне, спробуйте ще раз");
                Console.ResetColor();
                Program.Start();
            }
        }

        public static void CheckSelectedFunction(int selectedNumber)
        {
            if (selectedNumber == -1)
            {
                Environment.ExitCode = selectedNumber;
                Console.WriteLine("Exiting...");
                Environment.Exit(Environment.ExitCode);
            }

            else if (selectedNumber == 1 || selectedNumber == 2)
            {
                var methods = new List<MethodDelegate>();

                if (selectedNumber == 1)
                {
                    methods.Add(AddCar.AddCarToFileMethod);
                    methods.Add(AddClient.AddClientToFileMethod);
                    methods.Add(AddMotorcycle.AddMotorcycleToFileMethod);
                    methods.Add(AddTruck.AddTruckToFileMethod);
                }

                else if (selectedNumber == 2)
                {
                    methods.Add(EditInfoAboutCar.EditInfoAboutCarMethod);
                    methods.Add(EditClientInfo.EditInfoAboutClientMethod);
                    methods.Add(EditMotorcycleInfo.EditInfoAboutMotorcycleMethod);
                    methods.Add(EditTruckInfo.EditInfoAboutTruckMethod);
                }

                methods.Add(PrintCars.PrintCarsMethod);
                methods.Add(PrintClients.PrintAllClients);


                ChooseAdd();
                void ChooseAdd()
                {
                    string textForAdding = "\n3. Додати ще один автомобіль.\n" +
                                "4. Додати ще одного клієнта\n" +
                                "5. Додати ще один мотоцикл\n" +
                                "6. Додати ще один грузовик";
                    string textForEditing = "\n3. Змінити ще один автомобіль.\n" +
                               "4. Змінити ще одного клієнта\n" +
                               "5. Змінити ще один мотоцикл\n" +
                               "6. Змінити ще один грузовик";

                    string prompt = selectedNumber == 1 ? "додати" : "редагувати";

                    Console.WriteLine($"Оберіть, що хочете {prompt}\n" +
                    "1. Автомобіль\n" +
                    "2. Клієнта\n" +
                    "3. Мотоцикл\n" +
                    "4. Грузовик");

                    if (!int.TryParse(Console.ReadLine(), out int selectedAction))
                    {
                        Console.WriteLine("Не вірно введене значення, спробуйте ще раз");
                        ChooseAdd();
                        return;
                    }

                    if (selectedAction == 1)
                    {
                        if (selectedNumber == 1)
                        {
                            AddCar.AddCarToFileMethod();
                            ExitOrContinueShorter(textForAdding, methods);
                        }
                        else if (selectedNumber == 2)
                        {
                            EditInfoAboutCar.EditInfoAboutCarMethod();
                            ExitOrContinueShorter(textForEditing, methods);
                        }
                    }
                    else if (selectedAction == 2)
                    {
                        if (selectedNumber == 1)
                        {
                            AddClient.AddClientToFileMethod();
                            ExitOrContinueShorter(textForAdding, methods);
                        }
                        else if (selectedNumber == 2)
                        {
                            EditClientInfo.EditInfoAboutClientMethod();
                            ExitOrContinueShorter(textForEditing, methods);
                        }
                    }
                    else if (selectedAction == 3)
                    {
                        if (selectedNumber == 1)
                        {
                            AddMotorcycle.AddMotorcycleToFileMethod();
                            ExitOrContinueShorter(textForAdding, methods);
                        }
                        else if (selectedNumber == 2)
                        {
                            EditMotorcycleInfo.EditInfoAboutMotorcycleMethod();
                            ExitOrContinueShorter(textForEditing, methods);
                        }
                    }
                    else if (selectedAction == 4) {
                        if (selectedNumber == 1)
                        {
                            AddTruck.AddTruckToFileMethod();
                            ExitOrContinueShorter(textForAdding, methods);
                        }
                        else if (selectedNumber == 2)
                        {
                            EditTruckInfo.EditInfoAboutTruckMethod();
                            ExitOrContinueShorter(textForEditing, methods);
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНе вірно введене значення, спробуйте ще раз\n");
                        Console.ResetColor();
                        ChooseAdd();
                        return;
                    }
                }
            }

            else if (selectedNumber == 3)
            {
                AutomationOfSelectionForClient.AutomationSearch();
                ExitOrContinueShorter();
            }

            else if (selectedNumber == 4)
            {
                var printMethods = new List<MethodDelegate>();
                printMethods.Add(PrintCars.PrintCarsMethod);
                printMethods.Add(PrintClients.PrintAllClients);
                printMethods.Add(PrintMotorcycle.PrintAllMotorcycles);
                printMethods.Add(PrintTruck.PrintAllTrucks);

                ChoosePrint(printMethods);

                void ChoosePrint(List<MethodDelegate> methods)
                {
                    Console.WriteLine("Оберіть, що хочете надрукувати\n" +
                        "1. Автомобілі\n" +
                        "2. Клієнтів\n" +
                        "3. Мотоцикли\n" +
                        "4. Грузовики");

                    int selectedNumberOfPrints = int.Parse(Console.ReadLine());

                    if (selectedNumberOfPrints == 1 || selectedNumberOfPrints == 2 || selectedNumberOfPrints == 3 || selectedNumber == 4)
                    {
                        methods[selectedNumberOfPrints - 1]();
                        ExitOrContinueShorter();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНе вірно введене значення, спробуйте ще раз");
                        Console.ResetColor();
                        ChoosePrint(methods);
                    }
                }
            }

            else if (selectedNumber == 5)
            {
                PerformSearch();
            }

            else if (selectedNumber == 6)
            {
                PerformDelete();
            }

            else if(selectedNumber == 7)
            {
                Order.CreateOrder();
            }
          

        }
        private static void PerformSearch()
        {
           
            Search.SearchMethod();
            List<MethodDelegate> methods = new List<MethodDelegate>();
            methods.Add(Search.SearchMethod);
            ExitOrContinueShorter("\n3. Зробити знову пошук.", methods);
        }

        private static void PerformDelete()
        {
            string textForDelete = "\n3. Видалити ще один автомобіль.\n" +
                    "4. Видалити ще одного клієнта\n" +
                    "5. Видалити ще один мотоцикл\n" +
                    "6. Видалити ще один грузовик";

            List<MethodDelegate> methods = new List<MethodDelegate>();
            methods.Add(DeleteVehicle.DeleteCar);
            methods.Add(DeleteClient.DeleteClientMethod);
            methods.Add(DeleteVehicle.DeleteMotorcycle);
            methods.Add (DeleteVehicle.DeleteTruck);
            Console.Write("Виберіть, що хочете видалити:\n" +
                "1. Автомобіль.\n" +
                "2. Клієнта.\n" +
                "3. Мотоцикл.\n" +
                "4. Грузовик.");
            int selectOfDelete = int.Parse(Console.ReadLine());
            if(selectOfDelete == 1)
            {
               
                DeleteVehicle.DeleteCar();
                ExitOrContinueShorter(textForDelete, methods);
            }
            else if (selectOfDelete == 2)
            {
                DeleteClient.DeleteClientMethod();
                ExitOrContinueShorter(textForDelete, methods);
            }
            else if (selectOfDelete == 3)
            {
                DeleteVehicle.DeleteMotorcycle();
                ExitOrContinueShorter(textForDelete, methods);
            }
            else if (selectOfDelete == 4)
            {
                DeleteVehicle.DeleteTruck();
                ExitOrContinueShorter(textForDelete, methods);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nЗначення введено невірно, спробуйте ще раз.\n");
                Console.ResetColor();
                PerformDelete();
            }
            
        }
    }
}