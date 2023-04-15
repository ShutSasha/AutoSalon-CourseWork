using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.MainFunctions
{
    internal class ExitOrComtinue
    {

        public static void ExitOrContinue(string outputText = MenuText.exitOrContinueOutputText)
        {

            string exitOrContinue = outputText;
            
            Console.WriteLine(exitOrContinue);

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber == 1)
            {
                Console.WriteLine("\nВи обрали функцію вийти до головного меню");
                Program.Start();
            }

            else if (selectedNumber == 2)
            {
                Console.WriteLine("Exiting...");
                Environment.Exit(Environment.ExitCode);
            }

            else if (selectedNumber == 3)
            {
                AddCar.AddCarToFileMethod();
                ExitOrContinue(MenuText.exitOrContinueForChanges + "\n3. Добавити ще один автомобіль");
            }

            else
            {
                Console.WriteLine("Значення введено не вірно, напишіть знову");
                ExitOrContinue();
            }
        }

        public static void ExitOrContinueEditCar(string outputText = MenuText.exitOrContinueOutputText)
        {

            string exitOrContinue = outputText;

            Console.WriteLine(exitOrContinue);

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber == 1)
            {
                Console.WriteLine("\nВи обрали функцію вийти до головного меню");
                Program.Start();
            }

            else if (selectedNumber == 2)
            {
                Console.WriteLine("Exiting...");
                Environment.Exit(Environment.ExitCode);
            }

            else if (selectedNumber == 3)
            {
                EditInfoAboutCar.EditInfoAboutCarMethod();
                ExitOrContinueEditCar(MenuText.exitOrContinueForChanges + "\n3. Зробити ще зміни");
            }

            else
            {
                Console.WriteLine("Значення введено не вірно, напишіть знову");
                ExitOrContinueEditCar();
            }
        }

        public static void ExitOrContinueForSearch(string outputText = MenuText.exitOrContinueOutputText)
        {
            string exitOrContinue = outputText;

            Console.WriteLine(exitOrContinue);

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber == 1)
            {
                Console.WriteLine("\nВи обрали функцію вийти до головного меню");
                Program.Start();
            }

            else if (selectedNumber == 2)
            {
                Console.WriteLine("Exiting...");
                Environment.Exit(Environment.ExitCode);
            }

            else if (selectedNumber == 3)
            {
                Search search= new Search();
                search.SearchMethod();
                ExitOrContinueForSearch(MenuText.exitOrContinueForChanges + "\n3. Зробити знову пошук.");
            }

            else
            {
                Console.WriteLine("Значення введено не вірно, напишіть знову");
                ExitOrContinueEditCar();
            }
        }

    }
}
