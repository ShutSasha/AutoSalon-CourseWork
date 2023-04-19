using System.Text;

namespace CarDealership.MainFunctions.ClientFunctions
{
    public class AddClient
    {
        static public void AddClientToFileMethod()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть Ваш ПІБ: ");
            string username = Console.ReadLine();

            Console.Write("Введіть номер телефону: ");
            string phone = Console.ReadLine();

            Console.Write("Введіть електронну пошту: ");
            string email = Console.ReadLine();

            Console.Write("Введіть бренд який би Ви хотіли: ");
            string PreferredBrand = Console.ReadLine();

            Console.Write("Enter the price from: ");
            int priceFrom;
            int.TryParse(Console.ReadLine(), out priceFrom);

            Console.Write("Enter the price to: ");
            int priceTo;
            int.TryParse(Console.ReadLine(), out priceTo);

            Console.Write("Enter the year from: ");
            int yearFrom;
            int.TryParse(Console.ReadLine(), out yearFrom);

            Console.Write("Enter the year to: ");
            int yearTo;
            int.TryParse(Console.ReadLine(), out yearTo);




            string fileName = "ClientDB.txt";
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\MainFunctions\\ClientFunctions"));
            string filePath = Path.Combine(projectPath, fileName);

            string[] lines = File.ReadAllLines(filePath);
            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;


            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{id},{username},{phone},{email},{PreferredBrand},{priceFrom},{priceTo},{yearFrom},{yearTo}");
            }

            Console.WriteLine("Client added to file successfully!");
        }
    }
}