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
                //throw new Exception("\nВведене значення не валідне.");
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
                AddCar.AddCarToFileMethod();
                List<MethodDelegate> methods = new List<MethodDelegate>();
                methods.Add(AddCar.AddCarToFileMethod);
                methods.Add(PrintAllCars.PrintAllCarsMethod);
                ExitOrContinue.ExitOrContinueShorter("\n3. Добавити ще один автомобіль" +
                    "\n4. Показати базу автомобілей", methods);
            }

            else if (selectedNumber == 2)
            {
                EditInfoAboutCar.EditInfoAboutCarMethod();
                List<MethodDelegate> methods = new List<MethodDelegate>();
                methods.Add(EditInfoAboutCar.EditInfoAboutCarMethod);
                methods.Add(PrintAllCars.PrintAllCarsMethod);
                ExitOrContinue.ExitOrContinueShorter("\n3. Зробити ще зміни" +
                    "\n4. Показати базу автомобілей", methods);
            }

            else if (selectedNumber == 5)
            {
                PrintAllCars.PrintAllCarsMethod();
                ExitOrContinue.ExitOrContinueShorter();
            }

            else if (selectedNumber == 6)
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

            else if (selectedNumber == 7)
            {
                Search search = new Search();
                search.SearchMethod();
                List<MethodDelegate> methods = new List<MethodDelegate>();
                methods.Add(search.SearchMethod);
                ExitOrContinue.ExitOrContinueShorter("\n3. Зробити знову пошук.", methods);
            }

            else if (selectedNumber == 8)
            {
                PrintAllCars.PrintAllCarsMethod();
                DeleteCar delete = new DeleteCar();
                Console.Write("\nВведіть id автомобіля, який хочете видалити");
                int id = Convert.ToInt32(Console.ReadLine());
                delete.DeleteCarMethod(id);
            }

            else if (selectedNumber == 9)
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
