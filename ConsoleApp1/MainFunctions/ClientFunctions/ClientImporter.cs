using CarDealership.Models;

namespace CarDealership.MainFunctions.ClientFunctions
{
    public class ClientImporter
    {
        public static List<Client> ImportClientsFromFile(string[] linesClients)
        {
            List<Client> allClients = new List<Client>();

            foreach (string line in linesClients)
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

            return allClients;
        }

        public static List<Client> ImportClientsFromFileForPrint(string[] linesClients)
        {
            List<Client> allClients = new List<Client>();

            foreach (string line in linesClients)
            {
                string[] values = line.Split(',');

                int id = int.Parse(values[0]);
                string name = values[1] != "0" ? values[1] : "Даних немає";
                string phone = values[2] != "0" ? values[2] : "Даних немає";
                string email = values[3] != "0" ? values[3] : "Даних немає";
                string preferredBrand = values[4] != "0" ? values[4] : "Даних немає";
                int minPrice = values[5] != "0" ? int.Parse(values[5]) : 0;
                int maxPrice = values[6] != "0" ? int.Parse(values[6]) : 9999999;
                int minYear = values[7] != "0" ? int.Parse(values[7]) : 1920;
                int maxYear = values[8] != "0" ? int.Parse(values[8]) : 2023;

                Client newClient = new Client(id, name, phone, email, preferredBrand, minPrice, maxPrice, minYear, maxYear);

                allClients.Add(newClient);
            }

            return allClients;
        }
    }
}
