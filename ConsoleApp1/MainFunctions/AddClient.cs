using System;
using System.Collections.Generic;
using System.IO;

namespace CarDealership.MainFunctions
{
    internal class AddClient
    {
        private readonly string _filePath;

        public AddClient(string filePath)
        {
            _filePath = filePath;
        }

        public void AddClientToFile()
        {
            List<Client> clients = new List<Client>();

            // Читаем данные из файла
            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);

                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');

                    Client client = new Client(
                        id: int.Parse(fields[0]),
                        firstName: fields[1],
                        lastName: fields[2],
                        email: fields[3],
                        phoneNumber: fields[4],
                        dateOfBirth: DateTime.Parse(fields[5])
                    );

                    clients.Add(client);
                }
            }

            // Считываем данные нового клиента
            Console.Write("Enter client's first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter client's last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter client's email: ");
            string email = Console.ReadLine();

            Console.Write("Enter client's phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter client's date of birth (in format MM/dd/yyyy): ");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.Write("Invalid date format, please try again (in format MM/dd/yyyy): ");
            }

            // Генерируем новый ID
            int newId = 1;
            if (clients.Count > 0)
            {
                newId = clients[clients.Count - 1].Id + 1;
            }

            // Создаем новый объект клиента и добавляем его в список
            Client newClient = new Client(
                id: newId,
                firstName: firstName,
                lastName: lastName,
                email: email,
                phoneNumber: phoneNumber,
                dateOfBirth: dateOfBirth
            );

            clients.Add(newClient);

            // Записываем данные в файл
            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                foreach (Client client in clients)
                {
                    sw.WriteLine("{0},{1},{2},{3},{4},{5}",
                        client.Id,
                        client.FirstName,
                        client.LastName,
                        client.Email,
                        client.PhoneNumber,
                        client.DateOfBirth.ToString("MM/dd/yyyy")
                    );
                }
            }

            Console.WriteLine("Client has been added successfully.");
        }
    }
}