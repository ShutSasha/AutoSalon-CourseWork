using CarDealership.MainFunctions;
using CarDealership.MainFunctions.CarFunctions;
using CarDealership.MainFunctions.ClientFunctions;
using CarDealership.MainFunctions.MotorcycleFunctions;
using static CarDealership.MainFunctions.ExitOrContinue;

namespace CarDealership.ValidatorsMethods
{
    internal class Validators
    {
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
                Console.WriteLine("Введене значення не валідне, спробуйте ще раз");
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
                }

                else if (selectedNumber == 2)
                {
                    methods.Add(EditInfoAboutCar.EditInfoAboutCarMethod);
                    methods.Add(EditClientInfo.EditInfoAboutClientMethod);
                }

                methods.Add(PrintAllCars.PrintAllCarsMethod);
                methods.Add(PrintClients.PrintAllClients);


                ChooseAdd();
                void ChooseAdd()
                {

                    string prompt = selectedNumber == 1 ? "додати" : "редагувати";

                    Console.WriteLine($"Оберіть, що хочете {prompt}\n" +
                    "1. Автомобіль\n" +
                    "2. Клієнта\n" +
                    "3. Мотоцикл");

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
                            ExitOrContinueShorter("\n3. Додати ще один автомобіль.\n" +
                                "4. Додати ще одного клієнта", methods);
                        }
                        else if (selectedNumber == 2)
                        {
                            EditInfoAboutCar.EditInfoAboutCarMethod();
                            ExitOrContinueShorter("\n3. Змінити ще один автомобіль.\n" +
                               "4. Змінити ще одного клієнта", methods);
                        }
                    }
                    else if (selectedAction == 2)
                    {
                        if (selectedNumber == 1)
                        {
                            AddClient.AddClientToFileMethod();
                            ExitOrContinueShorter("\n3. Додати ще один автомобіль.\n" +
                               "4. Додати ще одного клієнта", methods);
                        }
                        else if (selectedNumber == 2)
                        {
                            EditClientInfo.EditInfoAboutClientMethod();
                            ExitOrContinueShorter("\n3. Змінити ще один автомобіль.\n" +
                               "4. Змінити ще одного клієнта", methods);
                        }
                    }
                    else if (selectedAction == 3)
                    {
                        if (selectedNumber == 1)
                        {
                            AddMotorcycle.AddMotorcycleToFileMethod();
                            ExitOrContinueShorter("\n3. Додати ще один автомобіль.\n" +
                                "4. Додати ще одного клієнта\n" +
                                "5. Додати мотоцикл", methods);
                        }
                        else if (selectedNumber == 2)
                        {
                            //EditInfoAboutCar.EditInfoAboutCarMethod();
                            //ExitOrContinueShorter("\n3. Змінити ще один автомобіль.\n" +
                            //   "4. Змінити ще одного клієнта", methods);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не вірно введене значення, спробуйте ще раз");
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
                printMethods.Add(PrintAllCars.PrintAllCarsMethod);
                printMethods.Add(PrintClients.PrintAllClients);
                printMethods.Add(PrintMotorcycle.PrintAllMotorcycles);

                ChoosePrint(printMethods);

                void ChoosePrint(List<MethodDelegate> methods)
                {
                    Console.WriteLine("Оберіть, що хочете надрукувати\n" +
                        "1. Автомобілі\n" +
                        "2. Клієнтів\n" +
                        "3. Мотоцикли");

                    int selectedNumberOfPrints = int.Parse(Console.ReadLine());

                    if (selectedNumberOfPrints == 1 || selectedNumberOfPrints == 2 || selectedNumberOfPrints == 3)
                    {
                        methods[selectedNumberOfPrints - 1]();
                        ExitOrContinueShorter();
                    }
                    else
                    {
                        Console.WriteLine("Не вірно введене значення, спробуйте ще раз");
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
                PerformDeleteCar();
            }

            else if (selectedNumber == 7)
            {
                PerformAddClient();
            }

        }
        private static void PerformSearch()
        {
            Search.SearchMethod();
            List<MethodDelegate> methods = new List<MethodDelegate>();
            methods.Add(Search.SearchMethod);
            ExitOrContinueShorter("\n3. Зробити знову пошук.", methods);
        }

        private static void PerformDeleteCar()
        {
            DeleteCar.DeleteCarMethod();
        }
        private static void PerformAddClient()
        {
            AddClient.AddClientToFileMethod();
            List<MethodDelegate> methods = new List<MethodDelegate>();
            methods.Add(AddClient.AddClientToFileMethod);
            ExitOrContinueShorter("\n3. Добавити ще одного клієнта", methods);
        }
    }
}