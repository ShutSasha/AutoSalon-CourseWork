using CarDealership.Models;
using ConsoleTables;

namespace CarDealership.MainFunctions.ClientFunctions
{
    public class PrintClients
    {
        static public void PrintAllClients()
        {
            AccessFile accessFileOfClients = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");
            string[] linesClients = accessFileOfClients.Lines;

            var allClients = ClientImporter.ImportClientsFromFileForPrint(linesClients);

            var table = new ConsoleTable("ID", "ПІБ", "Телефон", "Електронна пошта", "Бажаний бренд", "Мінімальна ціна", "Максимальна ціна", " Мін. рік випуску", "Макс. рік випуску");

            foreach (Client client in allClients)
            {
                table.AddRow(
                  client.Id,
                  client.Name,
                  client.Phone,
                  client.Email,
                  client.PreferredBrand,
                  client.MinPrice,
                  client.MaxPrice,
                  client.MinYear,
                  client.MaxYear
                   );

            }
            Console.Write(table.ToString());
        }
    }
}
