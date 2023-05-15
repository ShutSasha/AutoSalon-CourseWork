using CarDealership.Utils;
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

        public static void ValidatorInputValue(int inputNumber, int maxNumberInInput, AutoSalon salon)
        {

            if (inputNumber > maxNumberInInput || inputNumber < 1 && inputNumber != -1)
            {
                MenuText.ErrorOutputText("Введене значення не валідне, спробуйте ще раз");

                var StartTheProgram = new StartTheProgram(salon);

                StartTheProgram.Start();
            }
        }

        public static void CheckSelectedFunction(int selectedNumber, AutoSalon salon, StartTheProgram toMainMenu)
        {
            switch (selectedNumber)
            {
                case 1:
                case 2:
                    AddOrEditVehicle(selectedNumber, salon);
                    break;
                case 3:
                    salon.AutomationSearch();
                    break;
                case 4:
                    ChoosePrint(salon);
                    break;
                case 5:
                    PerformSearch(salon);
                    break;
                case 6:
                    PerformDelete(salon, toMainMenu);
                    break;
                case 7:
                    MakeAnOrder(salon, toMainMenu);
                    break;
                case -1:
                    ExitTheProgram(salon);
                    break;
                default:
                    break;
            }
        }
        private static void AddOrEditVehicle(int selectedNumber, AutoSalon salon)
        {
            string prompt = selectedNumber == 1 ? "додати" : "редагувати";
            var methods = new List<MethodDelegate>
            {
                 salon.AddCarToList,
                 salon.AddClientToList,
                 salon.AddMotorcycleToList,
                 salon.AddTruckToList,
            };

            Console.WriteLine($"Оберіть, що хочете {prompt}\n" +
                "1. Автомобіль\n" +
                "2. Клієнта\n" +
                "3. Мотоцикл\n" +
                "4. Грузовик");

            MenuText.OutputEnterNumOfFunc();

            if (!int.TryParse(Console.ReadLine(), out int selectedAction))
            {
                Console.WriteLine("Не вірно введене значення, спробуйте ще раз");
                AddOrEditVehicle(selectedNumber, salon);
                return;
            }

            var methodsToExecute = new List<MethodDelegate>();

            switch (selectedAction)
            {
                case 1:
                    methodsToExecute.Add(selectedNumber == 1 ? salon.AddCarToList : salon.EditInfoAboutCarMethod);
                    break;
                case 2:
                    methodsToExecute.Add(selectedNumber == 1 ? () => salon.AddClientToList() : salon.EditInfoAboutClient);
                    break;
                case 3:
                    methodsToExecute.Add(selectedNumber == 1 ? salon.AddMotorcycleToList : salon.EditInfoAboutBikes);
                    break;
                case 4:
                    methodsToExecute.Add(selectedNumber == 1 ? salon.AddTruckToList : salon.EditInfoAboutTrucks);
                    break;
                default:
                    MenuText.ErrorOutputText("\nНе вірно введене значення, спробуйте ще раз\n");
                    AddOrEditVehicle(selectedNumber, salon);
                    return;
            }

            methodsToExecute.Add(() => ExitOrContinueShorter(salon, selectedNumber == 1 ? MenuText.textForAdding : MenuText.textForEditing, methods));
            ExecuteMethods(methodsToExecute);
        }

        private static void ExecuteMethods(List<MethodDelegate> methods)
        {
            foreach (var method in methods)
            {
                method();
            }
        }
        private static void ChoosePrint(AutoSalon salon)
        {
            var printMethods = new List<MethodDelegate>();
            printMethods.Add(salon.PrintCars);
            printMethods.Add(salon.PrintClients);
            printMethods.Add(salon.PrintMotorcycle);
            printMethods.Add(salon.PrintTruck);
            printMethods.Add(salon.PrintSuppliers);
            printMethods.Add(salon.PrintCarriers);
            printMethods.Add(salon.PrintReceipts);

            int selectedNumberOfPrints = PrintInputValidator(printMethods.Count);

            if (selectedNumberOfPrints > 0 && selectedNumberOfPrints <= 7)
            {
                printMethods[selectedNumberOfPrints - 1]();
                var continuePrint = new List<MethodDelegate>();
                continuePrint.Add(() => ChoosePrint(salon));
                ExitOrContinueShorter(salon, "\n3. Повторити пошук", continuePrint);
            }
            else
            {
                MenuText.ErrorOutputText("\nНе вірно введене значення, спробуйте ще раз\n");
                ChoosePrint(salon);
            }
        }
        private static int PrintInputValidator(int maxNum)
        {
            while (true)
            {
                Console.WriteLine(MenuText.ChooseBetweenAllPrints);
                MenuText.OutputEnterNumOfFunc();

                string input = Console.ReadLine()?.Trim()!;

                if (int.TryParse(input, out int selectedNum))
                {
                    if (selectedNum >= 1 && selectedNum <= maxNum)
                    {
                        return selectedNum;
                    }
                }

                MenuText.ErrorOutputText($"Неправильний ввід. Будь ласка, введіть число від 1 до {maxNum}.");
            }
        }
        private static void PerformSearch(AutoSalon salon)
        {
            salon.SearchMethod();
            List<MethodDelegate> methods = new List<MethodDelegate>();
            methods.Add(salon.SearchMethod);
            ExitOrContinueShorter(salon, "\n3. Зробити знову пошук.", methods);
        }
        private static void PerformDelete(AutoSalon salon, StartTheProgram toMainMenu)
        {
            string textForDelete = "\n3. Видалити ще один автомобіль.\n" +
                                    "4. Видалити ще одного клієнта\n" +
                                    "5. Видалити ще один мотоцикл\n" +
                                    "6. Видалити ще один грузовик";

            List<MethodDelegate> methods = new List<MethodDelegate>();
            methods.Add(() => salon.RemoveCar(toMainMenu));
            methods.Add(() => salon.RemoveClient(toMainMenu));
            methods.Add(() => salon.RemoveBike(toMainMenu));
            methods.Add(() => salon.RemoveTruck(toMainMenu));

            int selectOfDelete = IntegerInputValidator();

            if (selectOfDelete == 1)
            {
                salon.RemoveCar(toMainMenu);
                ExitOrContinueShorter(salon, textForDelete, methods);
            }
            else if (selectOfDelete == 2)
            {
                salon.RemoveClient(toMainMenu);
                ExitOrContinueShorter(salon, textForDelete, methods);
            }
            else if (selectOfDelete == 3)
            {
                salon.RemoveBike(toMainMenu);
                ExitOrContinueShorter(salon, textForDelete, methods);
            }
            else if (selectOfDelete == 4)
            {
                salon.RemoveTruck(toMainMenu);
                ExitOrContinueShorter(salon, textForDelete, methods);
            }
            else
            {
                MenuText.ErrorOutputText("\nЗначення введено невірно, спробуйте ще раз.\n");
                PerformDelete(salon, toMainMenu);
            }
        }
        private static void MakeAnOrder(AutoSalon salon, StartTheProgram toMainMenu)
        {
            salon.PlaceOrder(toMainMenu);
        }
        private static void ExitTheProgram(AutoSalon salon)
        {
            
            Console.WriteLine("Saving data... Exiting...");
            Thread.Sleep(1000);
            salon.SaveData();
            
            Environment.Exit(0);
        }
        private static int IntegerInputValidator()
        {
            int result;

            while (true)
            {
                Console.Write("Виберіть, що хочете видалити:\n" +
                "1. Автомобіль.\n" +
                "2. Клієнта.\n" +
                "3. Мотоцикл.\n" +
                "4. Грузовик.");

                MenuText.OutputEnterNumOfFunc();

                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз.");
            }
        }
    }
}