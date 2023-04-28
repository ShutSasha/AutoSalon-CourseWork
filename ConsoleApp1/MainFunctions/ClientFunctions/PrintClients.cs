namespace CarDealership.MainFunctions.ClientFunctions
{
    using System.Text;
    using CarDealership.Models;

    public class PrintClients
    {
        static public void PrintAllClients()
        {
            AccessFile accessFileOfClients = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");
            string[] linesClients = accessFileOfClients.Lines;

            var allClients = ClientImporter.ImportClientsFromFileForPrint(linesClients);

            foreach (Client client in allClients)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine($"Id:{client.Id}, ПІБ: {client.Name}, Телефон: {client.Phone},\nЕлектронна пошта: {client.Email}, Бажаний бренд: {client.PreferredBrand}, Мінімальна ціна: {client.MinPrice},\nМаксимальна ціна: {client.MaxPrice}, Мінімальний бажаний рік випуску: {client.MinYear}, Максимальний бажаний рік випуску: {client.MaxYear} \n---------------------------------------------------------------------");

            }
        }
    }
}
