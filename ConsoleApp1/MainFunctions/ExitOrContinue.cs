using CarDealership.Utils;

namespace CarDealership.MainFunctions
{
    public class ExitOrContinue
    {
        public delegate void MethodDelegate();

        public static void ExitOrContinueShorter(string textOfNewAction = "", List<MethodDelegate> methods = null)
        {
            Console.WriteLine(MenuText.exitOrContinueForChanges + textOfNewAction);
           
            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nВи обрали функцію вийти до головного меню");
                Console.ResetColor();

                Program.Start();
            }

            else if (selectedNumber == 2)
            {
                Console.WriteLine("Exiting...");
                Environment.Exit(Environment.ExitCode);
            }

            else if (methods != null && selectedNumber >= 3 && selectedNumber <= 2 + methods.Count)
            {
                int index = selectedNumber - 3;
                methods[index]();
                ExitOrContinueShorter(textOfNewAction, methods);
            }
            else
            {
                if (methods != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nЗначення введено не вірно, напишіть знову");
                    Console.ResetColor();
                    ExitOrContinueShorter(textOfNewAction, methods);
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nЗначення введено не вірно, напишіть знову");
                    Console.ResetColor();
                    ExitOrContinueShorter(textOfNewAction, null);
                }
            }
        }
    }
}