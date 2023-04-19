namespace CarDealership.MainFunctions
{
    public class ExitOrContinue
    {
        public delegate void MethodDelegate();

        public static void ExitOrContinueShorter(string textOfNewAction = "", List<MethodDelegate> methods = null)
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
                    Console.WriteLine("Значення введено не вірно, напишіть знову");

                    ExitOrContinueShorter(textOfNewAction, methods);
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