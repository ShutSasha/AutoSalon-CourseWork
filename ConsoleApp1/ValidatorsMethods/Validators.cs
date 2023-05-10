using CarDealership.MainFunctions;
using CarDealership.MainFunctions.CarFunctions;
using CarDealership.MainFunctions.ClientFunctions;
using CarDealership.MainFunctions.MotorcycleFunctions;
using CarDealership.MainFunctions.OrderF;
using CarDealership.MainFunctions.TruckFunctions;
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

        public static void ValidatorInputValue(int inputNumber, int maxNumberInInput)
        {

            if (inputNumber > maxNumberInInput || inputNumber < 1 && inputNumber != -1)
            {
                MenuText.ErrorOutputText("Введене значення не валідне, спробуйте ще раз");

                var StartTheProgram = new StartTheProgram();

                StartTheProgram.Start();
            }
        }

        public static void CheckSelectedFunction(int selectedNumber)
        {
            switch (selectedNumber)
            {
                case 1:
                case 2:
                    AddOrEditVehicle(selectedNumber);
                    break;
                case 3:
                    AutomationOfSelectionForClient.AutomationSearch();
                    break;
                case 4:
                    ChoosePrint();
                    break;
                case 5:
                    PerformSearch();
                    break;
                case 6:
                    PerformDelete();
                    break;
                case 7:
                    MakeAnOrder();
                    break;
                case -1:
                    ExitTheProgram();
                    break;
                default:
                    break;
            }
        }
        private static void AddOrEditVehicle(int selectedNumber)
        {
            string prompt = selectedNumber == 1 ? "додати" : "редагувати";
            var methods = new List<MethodDelegate>
            {
                 AddCar.AddCarToFileMethod,
                 AddClient.AddClientToFileMethod,
                 AddMotorcycle.AddMotorcycleToFileMethod,
                 AddTruck.AddTruckToFileMethod,
                 PrintCars.PrintCarsMethod,
                 PrintClients.PrintAllClients
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
                AddOrEditVehicle(selectedNumber);
                return;
            }

            var methodsToExecute = new List<MethodDelegate>();

            switch (selectedAction)
            {
                case 1:
                    methodsToExecute.Add(selectedNumber == 1 ? AddCar.AddCarToFileMethod : EditInfoAboutCar.EditInfoAboutCarMethod);
                    break;
                case 2:
                    methodsToExecute.Add(selectedNumber == 1 ? AddClient.AddClientToFileMethod : EditClientInfo.EditInfoAboutClientMethod);
                    break;
                case 3:
                    methodsToExecute.Add(selectedNumber == 1 ? AddMotorcycle.AddMotorcycleToFileMethod : EditMotorcycleInfo.EditInfoAboutMotorcycleMethod);
                    break;
                case 4:
                    methodsToExecute.Add(selectedNumber == 1 ? AddTruck.AddTruckToFileMethod : EditTruckInfo.EditInfoAboutTruckMethod);
                    break;
                default:
                    MenuText.ErrorOutputText("\nНе вірно введене значення, спробуйте ще раз\n");
                    AddOrEditVehicle(selectedNumber);
                    return;
            }

            methodsToExecute.Add(() => ExitOrContinueShorter(selectedNumber == 1 ? MenuText.textForAdding : MenuText.textForEditing, methods));
            ExecuteMethods(methodsToExecute);
        }

        private static void ExecuteMethods(List<MethodDelegate> methods)
        {
            foreach (var method in methods)
            {
                method();
            }
        }
        private static void ChoosePrint()
        {
            var printMethods = new List<MethodDelegate>();
            printMethods.Add(PrintCars.PrintCarsMethod);
            printMethods.Add(PrintClients.PrintAllClients);
            printMethods.Add(PrintMotorcycle.PrintAllMotorcycles);
            printMethods.Add(PrintTruck.PrintAllTrucks);
            printMethods.Add(PrintOrder.PrintOrdersMethod);

            Console.WriteLine(MenuText.ChooseBetweenAllPrints);

            MenuText.OutputEnterNumOfFunc();

            int selectedNumberOfPrints = int.Parse(Console.ReadLine());

            if (selectedNumberOfPrints > 0 && selectedNumberOfPrints <= 5)
            {
                printMethods[selectedNumberOfPrints - 1]();
                var continuePrint = new List<MethodDelegate>();
                continuePrint.Add(ChoosePrint);
                ExitOrContinueShorter("\n3. Повторити пошук", continuePrint);
            }
            else
            {
                MenuText.ErrorOutputText("\nНе вірно введене значення, спробуйте ще раз\n");
                ChoosePrint();
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
            methods.Add(DeleteVehicle.DeleteTruck);
            Console.Write("Виберіть, що хочете видалити:\n" +
                "1. Автомобіль.\n" +
                "2. Клієнта.\n" +
                "3. Мотоцикл.\n" +
                "4. Грузовик.");
            MenuText.OutputEnterNumOfFunc();
            int selectOfDelete = int.Parse(Console.ReadLine());
            if (selectOfDelete == 1)
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
                MenuText.ErrorOutputText("\nЗначення введено невірно, спробуйте ще раз.\n");
                PerformDelete();
            }
        }
        private static void MakeAnOrder()
        {
            Order.CreateOrder();
        }
        private static void ExitTheProgram()
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
    }
}