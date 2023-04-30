using CarDealership.ValidatorsMethods;
using System.Text;

namespace CarDealership.MainFunctions.TruckFunctions
{
    internal class AddTruck
    {
        public static void AddTruckToFileMethod()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть назву бренду(Honda) грузовика: ");
            string? brand = Console.ReadLine();

            int year = Validators.YearInputOfVehicle();

            Console.Write("Введіть модель грузовика: ");
            string? model = Console.ReadLine();

            Console.Write("Введіть колір грузовика: ");
            string? color = Console.ReadLine();

            Console.Write("Введіть стан грузовика(good, normal): ");
            string? condition = Console.ReadLine();

            Console.Write("Введіть ціну грузовика: ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість колес грузовика: ");
            int numberOfWheels = int.Parse(Console.ReadLine());

            Console.Write("Введіть вантажопідйомність грузовика(У тоннах): ");
            int loadCapacity = int.Parse(Console.ReadLine());

            AccessFile accessFile = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            string[] lines = accessFile.Lines;
            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;

            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{id},{brand},{year},{model},{color},{condition},{price},{numberOfWheels},{loadCapacity}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nTruck added to file successfully!");
            Console.ResetColor();
        }
    }
}
