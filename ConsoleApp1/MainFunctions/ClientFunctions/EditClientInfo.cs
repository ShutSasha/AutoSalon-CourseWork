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

            AccessFile accessFileOfClients = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");
            string[] linesClients = accessFileOfClients.Lines;

            Console.OutputEncoding = Encoding.UTF8;

            var allClients = ClientImporter.ImportClientsFromFile(linesClients);
            PrintClients.PrintAllClients();

            Console.Write("\nВведіть id клієнта: ");
            int id = int.Parse(Console.ReadLine());

            bool checkId = CheckIdExists.CheckClientExistID(allClients, id);

            if (checkId)
            {
                EditClientInfo changesAboutClient = new EditClientInfo();
                changesAboutClient.SelectChanges(linesClients, id, accessFileOfClients.FilePath);
            }

            else
            {
                Console.WriteLine("\nВи ввели неіснуючий id клієнта, спробуйте ще раз");
                EditInfoAboutClientMethod();
            }
        }
    }
}
