using CarDealership.MainFunctions;
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
                throw new Exception("Input value is not valid.");
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

            else if (selectedNumber == 6)
            {
                Console.WriteLine();
                PrintAllCars.PrintAllCarsMethod();
                ExitOrContinue.ExitOrContinueShorter();
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
        }
    }
}
