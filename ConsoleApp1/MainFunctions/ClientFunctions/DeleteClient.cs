using CarDealership.Models;
using CarDealership.Utils;

namespace CarDealership.MainFunctions.ClientFunctions
{
    internal class DeleteClient
    {
        public static void DeleteClientMethod()
        {
           
            PrintClients.PrintAllClients();

            Console.Write("\nВведіть id клієнта, якого хочете видалити: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());

            AccessFile accessFile = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");
            string[] lines = accessFile.Lines;

            // Пошук індексу рядка з айді, який потрібно видалити
            int indexToDelete = -1;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                int id = int.Parse(values[0]);

                if (id == idToDelete)
                {
                    indexToDelete = i;
                    break;
                }
            }

            if (indexToDelete == -1)
            {
                Console.WriteLine($"Клієнта з айді {idToDelete} не знайдено в файлі.");
                return;
            }

            // Видаляємо рядок з файлу
            List<string> newLines = lines.ToList();
            newLines.RemoveAt(indexToDelete);
            lines = newLines.ToArray();

            // Перезаписуємо файл
            using (StreamWriter writer = new StreamWriter(accessFile.FilePath))
            {
                for (int i = lines.Length - 1; i >= 0; i--)
                {
                    writer.WriteLine(lines[i]);
                }
            }


            List<Client> clients = new List<Client>();
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                int id = int.Parse(fields[0]);
                string name = fields[1];
                string phone = fields[2];
                string email = fields[3];
                string preferredBrand = fields[4];
                int minPrice = int.Parse(fields[5]);
                int maxPrice = int.Parse(fields[6]);
                int minYear = int.Parse(fields[7]);
                int maxYear = int.Parse(fields[8]);
                Client client = new Client(id, name, phone, email, preferredBrand, minPrice, maxPrice, minYear, maxYear);
                clients.Add(client);
            }

            clients = clients.OrderBy(client => client.Id).ToList();

            using (StreamWriter sw = new StreamWriter(accessFile.FilePath))
            {
                foreach (Client client in clients)
                {
                    string line = $"{client.Id},{client.Name},{client.Phone},{client.Email},{client.PreferredBrand},{client.MinPrice},{client.MaxPrice},{client.MinYear},{client.MaxYear}";
                    sw.WriteLine(line);
                }
            }
            Array.Sort(lines, (a, b) => int.Parse(a.Split(',')[0]).CompareTo(int.Parse(b.Split(',')[0])));

            // Перезаписуємо файл з відсортованими рядками та новими айді
            using (StreamWriter writer = new StreamWriter(accessFile.FilePath))
            {
                int newId = 1;

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    parts[0] = newId.ToString();
                    writer.WriteLine(string.Join(',', parts));
                    newId++;
                }
            }

            MenuText.SuccessOutput($"\nКлієнт з айді {idToDelete} успішно видалений з файлу.\n");

        }
    }
}