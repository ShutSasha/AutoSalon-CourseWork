using CarDealership.Models;
using CarDealership.ValidatorsMethods;
using System.Text;

namespace CarDealership.MainFunctions.ClientFunctions
{
    public class EditClientInfo
    {
        public void SelectChanges(string[] lines, int id, string filePath)
        {
            Console.WriteLine("Оберіть, що ви хочете в ньому змінити\n" + "1. ПІБ\n" + "2. Телефон\n" + "3. Пошту\n" + "4. Бажаний бренд\n" + "5. Мінімальна ціна\n" + "6. Максимальна ціна\n" + "7. Мінімальний рік випуску\n" +
                "8. Максимальний рік випуску");

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber >= 1 && selectedNumber <= 8)
            {
                string[] fieldNames = { "ПІБ", "Телефон", "Пошта", "Бажаний бренд", "Мінімальна ціна", "Максимальна ціна", "Мінімальний рік випуску", "Максимальний рік випуску" };
                Console.Write($"Введіть нове значення для поля '{fieldNames[selectedNumber - 1]}': ");
                string newValue = Console.ReadLine();
                string[] clientData = lines[id - 1].Split(',');
                clientData[selectedNumber] = newValue;
                lines[id - 1] = string.Join(",", clientData);
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Поле '{fieldNames[selectedNumber - 1]}' змінено на '{newValue}'");


            }
            else
            {
                Console.WriteLine("Ви ввели неіснуючу функцію, спробуйте ще раз");
                SelectChanges(lines, id, filePath);
            }
        }
        public static void EditInfoAboutClientMethod()
        {

            string fileName = "ClientDb.txt";
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\MainFunctions\\ClientFunctions"));
            string filePath = Path.Combine(projectPath, fileName);

            string[] lines = File.ReadAllLines(filePath);

            Console.OutputEncoding = Encoding.UTF8;

            List<Client> allClients = new List<Client>();
            PrintClients.PrintAllClients();

            Console.Write("\nВведіть id клієнта: ");
            int id = int.Parse(Console.ReadLine());

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                int idParse = int.Parse(values[0]);
                string name = values[1];
                string phone = values[2];
                string email = values[3];
                string preferredBrand = values[4];
                int minPrice = int.Parse(values[5]);
                int maxPrice = int.Parse(values[6]);
                int minYear = int.Parse(values[7]);
                int maxYear = int.Parse(values[8]);

               
                Client newClient = new Client(idParse, name, phone, email, preferredBrand, minPrice, maxPrice, minYear, maxYear);

                allClients.Add(newClient);
            }

            bool checkId = CheckIdExists.CheckClientExistID(allClients, id);

            if (checkId)
            {
                EditClientInfo changesAboutClient = new EditClientInfo();
                changesAboutClient.SelectChanges(lines, id, filePath);
            }

            else
            {

                Console.WriteLine("\nВи ввели неіснуючий id клієнта, спробуйте ще раз");
                EditInfoAboutClientMethod();

            }

        }
    }
}
