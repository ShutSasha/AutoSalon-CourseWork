using CarDealership.MainFunctions;
using CarDealership.MainFunctions.ClientFunctions;
using System.Security.Cryptography.X509Certificates;
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

            else if (selectedNumber == 1)
            {

                List<MethodDelegate> methods = new List<MethodDelegate>();
                methods.Add(AddCar.AddCarToFileMethod);
                methods.Add(AddClient.AddClientToFileMethod);
                methods.Add(PrintAllCars.PrintAllCarsMethod);
                methods.Add(PrintClients.PrintAllClients);

                ChooseAdd();
                void ChooseAdd()
                {
                    Console.WriteLine("Оберіть, що хочете додати\n" +
                    "1. Автомобілі\n" +
                    "2. Клієнтів");

                    int selectedNumberOfAdd = int.Parse(Console.ReadLine());

                    if (selectedNumberOfAdd == 1)
                    {
                        AddCar.AddCarToFileMethod();
                        ExitOrContinue.ExitOrContinueShorter("\n3. Добавити ще один автомобіль." +
                    "\n4. Добавити ще одного клієнта." +
                    "\n5. Показати базу автомобілів." +
                    "\n6. Показати базу клієнтівю", methods);
                        
                    }
                    else if (selectedNumberOfAdd == 2)
                    {
                        AddClient.AddClientToFileMethod();
                        ExitOrContinue.ExitOrContinueShorter("\n3. Добавити ще один автомобіль." +
                    "\n4. Добавити ще одного клієнта." +
                    "\n5. Показати базу автомобілів." +
                    "\n6. Показати базу клієнтів", methods);
                    }

                    else
                    {
                        Console.WriteLine("Не вірно введене значення, спробуйте ще раз");
                        ChooseAdd();
                    }
                }
            }

            else if (selectedNumber == 2)
            {
                List<MethodDelegate> methods = new List<MethodDelegate>();
                methods.Add(EditInfoAboutCar.EditInfoAboutCarMethod);
                methods.Add(EditClientInfo.EditInfoAboutClientMethod);
                methods.Add(PrintAllCars.PrintAllCarsMethod);
                methods.Add(PrintClients.PrintAllClients);



                ChooseAdd();
                void ChooseAdd()
                {
                    Console.WriteLine("Оберіть, що хочете додати\n" +
                    "1. Редагувати автомобіль\n" +
                    "2. Редагувати клієнта\n" +
                    "3. Показати базу автомобілів\n" +
                    "4. Показати базу клієнтів");

                    int selectedNumberOfAdd = int.Parse(Console.ReadLine());

                    if (selectedNumberOfAdd == 1)
                    {
                        EditInfoAboutCar.EditInfoAboutCarMethod();
                        ExitOrContinue.ExitOrContinueShorter("\n3. Редагувати ще один автомобіль." +
                    "\n4. Редагувати ще одного клієнта." +
                    "\n5. Показати базу автомобілів." +
                    "\n6. Показати базу клієнтівю", methods);

                    }
                    else if (selectedNumberOfAdd == 2)
                    {
                       EditClientInfo.EditInfoAboutClientMethod();
                        ExitOrContinue.ExitOrContinueShorter("\n3. Добавити ще один автомобіль." +
                    "\n4. Добавити ще одного клієнта." +
                    "\n5. Показати базу автомобілів." +
                    "\n6. Показати базу клієнтівю", methods);
                    }

                    else
                    {
                        Console.WriteLine("Не вірно введене значення, спробуйте ще раз");
                        ChooseAdd();
                    }
                }
            }
            
              
            else if (selectedNumber == 3)
            {
                AutomationOfSelectionForClient.AutomationSearch();
                ExitOrContinue.ExitOrContinueShorter();
            }

            else if (selectedNumber == 4)
            {
                ChoosePrint();

                void ChoosePrint()
                {
                    Console.WriteLine("Оберіть, що хочете надрукувати\n" +
                    "1. Автомобілі\n" +
                    "2. Клієнтів");

                    int selectedNumberOfPrints = int.Parse(Console.ReadLine());

                    if (selectedNumberOfPrints == 1)
                    {
                        PrintAllCars.PrintAllCarsMethod();
                        ExitOrContinue.ExitOrContinueShorter();
                    }
                    else if (selectedNumberOfPrints == 2)
                    {
                        PrintClients.PrintAllClients();
                        ExitOrContinue.ExitOrContinueShorter();
                    }

                    else
                    {
                        Console.WriteLine("Не вірно введене значення, спробуйте ще раз");
                        ChoosePrint();
                    }
                }


            }

            else if (selectedNumber == 5)
            {
                Search search = new Search();
                search.SearchMethod();
                List<MethodDelegate> methods = new List<MethodDelegate>();
                methods.Add(search.SearchMethod);
                ExitOrContinue.ExitOrContinueShorter("\n3. Зробити знову пошук.", methods);
            }

            else if (selectedNumber == 6)
            {
                PrintAllCars.PrintAllCarsMethod();
                DeleteCar delete = new DeleteCar();
                Console.Write("\nВведіть id автомобіля, який хочете видалити");
                int id = Convert.ToInt32(Console.ReadLine());
                delete.DeleteCarMethod(id);
            }

            else if (selectedNumber == 7)
            {
                //AddCar.AddCarToFileMethod();
                AddClient.AddClientToFileMethod();
                List<MethodDelegate> methods = new List<MethodDelegate>();
                methods.Add(AddClient.AddClientToFileMethod);
                ExitOrContinue.ExitOrContinueShorter("\n3. Добавити ще одного клієнта", methods);
            }


        }
    }
}
