using System.Text;
using CarDealership.MainFunctions;
using CarDealership.ValidatorsMethods;

namespace CarDealership
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Start(); 
        }

        public static void Start()
        {
            string chooseOneFunction = MenuText.chooseOneFunction;
            bool checkLoop = true;

            do
            {
                Console.WriteLine(chooseOneFunction);

                Console.Write("\nНапишіть тут номер функції, яку хочете виконати: ");
                int selectedNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Validators.ValidatorInputValue(selectedNumber, Validators.FindMaxNumberInString(chooseOneFunction));


                Validators.CheckSelectedFunction(selectedNumber);
                if (selectedNumber == -1)
                {
                    checkLoop = false;
                }
            } while (checkLoop);
        }

    }
}