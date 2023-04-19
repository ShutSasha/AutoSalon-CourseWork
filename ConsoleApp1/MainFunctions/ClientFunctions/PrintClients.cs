﻿namespace CarDealership.MainFunctions.ClientFunctions
{
    using System.Text;

    public class PrintClients
    {
        static public void PrintAllClients()
        {
            List<Client> allClients = new List<Client>();
            Console.OutputEncoding = Encoding.UTF8;

            string fileName = "ClientDB.txt";
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\MainFunctions\\ClientFunctions"));
            string filePath = Path.Combine(projectPath, fileName);

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                int id = int.Parse(values[0]);
                string name = values[1] != "0" ? values[1] : "Даних немає";
                string phone = values[2] != "0" ? values[2] : "Даних немає";
                string email = values[3] != "0" ? values[3] : "Даних немає";
                string preferredBrand = values[4] != "0" ? values[4] : "Даних немає";
                int minPrice = values[5] != "0" ? int.Parse(values[5]) : 0;
                int maxPrice = values[6] != "0" ? int.Parse(values[6]) : 9999999;
                int minYear = values[7] != "0" ? int.Parse(values[7]) : 1900;
                int maxYear = values[8] != "0" ? int.Parse(values[8]) : 2023;
                
                Client newCar = new Client(id, name, phone, email, preferredBrand, minPrice, maxPrice, minYear, maxYear);

                allClients.Add(newCar);
            }

            foreach (Client client in allClients)
            {

                Console.WriteLine($"Id:{client.Id}, ПІБ: {client.Name}, Телефон: {client.Phone},\nЕлектронна пошта: {client.Email}, Бажаний бренд: {client.PreferredBrand}, Мінімальна ціна: {client.MinPrice},\nМаксимальна ціна: {client.MaxPrice}, Мінімальний бажаний рік випуску: {client.MinYear}, Максимальний бажаний рік випуску: {client.MaxYear} \n---------------------------------------------------------------------");

            }
        }
    }


}
