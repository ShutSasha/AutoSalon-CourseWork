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
                Program.Start();
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

            ChooseAddOrEditVehicle(selectedNumber, methods);
        }
        private static void ChooseAddOrEditVehicle(int selectedNumber, List<MethodDelegate> methods)
        {
            string prompt = selectedNumber == 1 ? "додати" : "редагувати";

            Console.WriteLine($"Оберіть, що хочете {prompt}\n" +
            "1. Автомобіль\n" +
            "2. Клієнта\n" +
            "3. Мотоцикл\n" +
            "4. Грузовик");

            MenuText.OutputEnterNumOfFunc();
            if (!int.TryParse(Console.ReadLine(), out int selectedAction))
            {
                Console.WriteLine("Не вірно введене значення, спробуйте ще раз");
                ChooseAddOrEditVehicle(selectedNumber, methods);
                return;
            }

            if (selectedAction == 1)
            {
                if (selectedNumber == 1)
                {
                    AddCar.AddCarToFileMethod();
                    ExitOrContinueShorter(MenuText.textForAdding, methods);
                }
                else if (selectedNumber == 2)
                {
                    EditInfoAboutCar.EditInfoAboutCarMethod();
                    ExitOrContinueShorter(MenuText.textForEditing, methods);
                }
            }
            else if (selectedAction == 2)
            {
                if (selectedNumber == 1)
                {
                    AddClient.AddClientToFileMethod();
                    ExitOrContinueShorter(MenuText.textForAdding, methods);
                }
                else if (selectedNumber == 2)
                {
                    EditClientInfo.EditInfoAboutClientMethod();
                    ExitOrContinueShorter(MenuText.textForEditing, methods);
                }
            }
            else if (selectedAction == 3)
            {
                if (selectedNumber == 1)
                {
                    AddMotorcycle.AddMotorcycleToFileMethod();
                    ExitOrContinueShorter(MenuText.textForAdding, methods);
                }
                else if (selectedNumber == 2)
                {
                    EditMotorcycleInfo.EditInfoAboutMotorcycleMethod();
                    ExitOrContinueShorter(MenuText.textForEditing, methods);
                }
            }
            else if (selectedAction == 4)
            {
                if (selectedNumber == 1)
                {
                    AddTruck.AddTruckToFileMethod();
                    ExitOrContinueShorter(MenuText.textForAdding, methods);
                }
                else if (selectedNumber == 2)
                {
                    EditTruckInfo.EditInfoAboutTruckMethod();
                    ExitOrContinueShorter(MenuText.textForEditing, methods);
                }
            }
            else
            {
                MenuText.ErrorOutputText("\nНе вірно введене значення, спробуйте ще раз\n");
                ChooseAddOrEditVehicle(selectedNumber, methods);
                return;
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