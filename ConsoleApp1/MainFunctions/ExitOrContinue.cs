using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.MainFunctions
{
    internal class ExitOrContinue
    {
        public static void ExitOrContinueProgram(string outputText = MenuText.exitOrContinueOutputText)
        {

            Console.WriteLine(MenuText.exitOrContinueForChanges);

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


            //ExitOrContinueShorter(outputText);
            else
            {
                Console.WriteLine("Значення введено не вірно, напишіть знову");
                ExitOrContinueProgram();
            }
        }
        public static void ExitOrContinueAddCar(string outputText = MenuText.exitOrContinueOutputText)
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
                ExitOrContinueAddCar(MenuText.exitOrContinueForChanges + "\n3. Добавити ще один автомобіль");
            }

            else
            {
                Console.WriteLine("Значення введено не вірно, напишіть знову");
                ExitOrContinueAddCar(MenuText.exitOrContinueForChanges + "\n3. Добавити ще один автомобіль");
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
                ExitOrContinueEditCar(MenuText.exitOrContinueForChanges + "\n3. Зробити ще зміни");
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
                Search search = new Search();
                search.SearchMethod();
                ExitOrContinueForSearch(MenuText.exitOrContinueForChanges + "\n3. Зробити знову пошук.");
            }

            else
            {
                Console.WriteLine("Значення введено не вірно, напишіть знову");
                ExitOrContinueEditCar(MenuText.exitOrContinueForChanges + "\n3. Зробити знову пошук.");
            }
        }
        public static void ExitOrContinueShorter(string textOfNewAction = "", Action? newFunc = null)
        {
            string outputText = MenuText.exitOrContinueOutputText;

            Console.WriteLine(outputText + textOfNewAction);

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

            else if (newFunc != null && selectedNumber == 3)
            {
                newFunc();
                ExitOrContinueShorter(textOfNewAction, newFunc);
            }
            else
            {
                if (newFunc != null)
                {
                    Console.WriteLine("Значення введено не вірно, напишіть знову");

                    ExitOrContinueShorter(textOfNewAction, newFunc);
                }

                else
                {
                    Console.WriteLine("Значення введено не вірно, напишіть знову");

                    ExitOrContinueShorter(textOfNewAction, null);
                }

            }
        }

    }
}
