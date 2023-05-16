using CarDealership.Utils;

namespace CarDealership.SecondaryFunctions
{
    public class ExitOrContinue
    {
        public delegate void MethodDelegate();

        public static void ExitOrContinueShorter(AutoSalon salon, string textOfNewAction = "", List<MethodDelegate> methods = null)
        {
            Console.WriteLine(MenuText.exitOrContinueForChanges + textOfNewAction);

            int selectedNumber = NumberInputValidator();

            if (selectedNumber == 1)
            {
                MenuText.BlueOutput("\nВи обрали функцію вийти до головного меню");

                var StartTheProgram = new StartTheProgram(salon);

                StartTheProgram.Start();
            }

            else if (selectedNumber == 2)
            {
                Console.WriteLine("Saving data... Exiting...");
                Thread.Sleep(1000);
                salon.SaveData();
                Environment.Exit(Environment.ExitCode);
            }

            else if (methods != null && selectedNumber >= 3 && selectedNumber <= 2 + methods.Count)
            {
                int index = selectedNumber - 3;
                methods[index]();
                ExitOrContinueShorter(salon, textOfNewAction, methods);
            }
            else
            {
                if (methods != null)
                {
                    MenuText.ErrorOutputText("\nЗначення введено не вірно, напишіть знову");
                    ExitOrContinueShorter(salon, textOfNewAction, methods);
                }

                else
                {
                    MenuText.ErrorOutputText("\nЗначення введено не вірно, напишіть знову");
                    ExitOrContinueShorter(salon, textOfNewAction, null);
                }
            }
        }
        private static int NumberInputValidator()
        {
            while (true)
            {
                MenuText.OutputEnterNumOfFunc();
                string input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int number))
                {
                    return number;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Введіть ціле число.");
            }
        }
    }
}