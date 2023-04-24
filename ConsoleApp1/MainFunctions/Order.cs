using CarDealership.MainFunctions.CarFunctions;
using CarDealership.MainFunctions.ClientFunctions;
using CarDealership.MainFunctions.MotorcycleFunctions;
using CarDealership.MainFunctions.TruckFunctions;
using CarDealership.Models;
using System.Text;
using static CarDealership.MainFunctions.ExitOrContinue;

namespace CarDealership.MainFunctions
{
    internal class Order
    {
        public static void CreateOrder()
        {
            Console.OutputEncoding = Encoding.UTF8;

            PrintClients.PrintAllClients();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nОбиріть клієнта з списку вище, який буде робити замовлення:\n");
            Console.ResetColor();

            Console.Write("\nВведіть id клієнта: ");
            int idClient = Convert.ToInt32(Console.ReadLine());

            AccessFile accessFileOfClients = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");
            string[] linesOfClients = accessFileOfClients.Lines;
            int indexToDelete = -1;
            // Пошук індексу рядка з айді, який потрібно видалити
            chooseClient();
            void chooseClient()
            {
                for (int i = 0; i < linesOfClients.Length; i++)
                {
                    string[] values = linesOfClients[i].Split(',');
                    int id = int.Parse(values[0]);

                    if (id == idClient)
                    {
                        indexToDelete = i;
                        break;
                    }
                }

                if (indexToDelete == -1)
                {
                    Console.WriteLine($"Клієнта з айді {idClient} не знайдено. Спробуйте ще раз");
                    chooseClient();
                }
            }


            Console.WriteLine($"Клієнт успішно обрайний.");



            // Клієнт обирає транспорт
            PerformDelete();
            void PerformDelete()
            {
                Console.Write("Виберіть, що хочете надрукувати, щоб потім обрати транспорт для покупки:\n" +
                    "1. Автомобілі.\n" +
                    "2. Мотоцикли.\n" +
                    "3. Грузовики.");
                int selectOfDelete = int.Parse(Console.ReadLine());
                if (selectOfDelete == 1)
                {
                    DeleteVehicle.DeleteCarForPurchased();
                }
                else if (selectOfDelete == 2)
                {
                    DeleteVehicle.DeleteMotorcycleForPurchased();

                }
                else if (selectOfDelete == 3)
                {
                    DeleteVehicle.DeleteTruckForPurchased();

                }

                else
                {
                    Console.WriteLine("Значення введено невірно, спробуйте ще раз.");
                    PerformDelete();
                }
            }

            int provider;
            bool providerBool = false;
            chooseProvider();
            void chooseProvider()
            {
                Console.Write("Обиріть постачальника нижче:\n" +
                                "1. Амереканський (Найдорожчий та найбільш якісний транспорт)\n" +
                                "2. Європейський (Якісний транспорт та найдійний постачальник)\n" +
                                "3. Постачальник з Японії (Якісний транспорт)");
                provider = Convert.ToInt32(Console.ReadLine());

                if (provider < 1 || provider > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Значення введено не правильно!");
                    Console.ResetColor();
                    chooseProvider();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Постачальник успішно обраний");
                    Console.ResetColor();
                    providerBool = true;
                }
            }
            int carrier;
            bool carrierBool = false;
            chooseCarrier();
            void chooseCarrier()
            {
                Console.Write("Обиріть перевізника нижче:\n" +
                                "1. Швидкий\n" +
                                "2. Із середньою швидкістю\n" +
                                "3. Повільний)");
                carrier = Convert.ToInt32(Console.ReadLine());

                if (carrier < 1 || carrier > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Значення введено не правильно!");
                    Console.ResetColor();
                    chooseCarrier();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Перевізник успішно обраний.\n Вітємо з покупкою!");
                    Console.ResetColor();
                    carrierBool = true;
                }
            }

            // тільке після того як обере постачальника та перевізника и напише Так для підтвердження
            bool confirmOrder = false;
            if (providerBool && carrierBool)
            {
                confirmOrder = true;
            }
            if (confirmOrder)
            {

                // Видаляємо рядок з файлу
                List<string> newLines = linesOfClients.ToList();
                newLines.RemoveAt(indexToDelete);
                linesOfClients = newLines.ToArray();

                // Перезаписуємо файл
                using (StreamWriter writer = new StreamWriter(accessFileOfClients.FilePath))
                {
                    for (int i = linesOfClients.Length - 1; i >= 0; i--)
                    {
                        writer.WriteLine(linesOfClients[i]);
                    }
                }


                List<Client> clients = new List<Client>();
                foreach (string line in linesOfClients)
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

                // Сортуємо клієнтів за айдішником
                clients = clients.OrderBy(client => client.Id).ToList();

                // Перезаписуємо файл
                using (StreamWriter sw = new StreamWriter(accessFileOfClients.FilePath))
                {
                    foreach (Client client in clients)
                    {
                        string line = $"{client.Id},{client.Name},{client.Phone},{client.Email},{client.PreferredBrand},{client.MinPrice},{client.MaxPrice},{client.MinYear},{client.MaxYear}";
                        sw.WriteLine(line);
                    }
                }
                Array.Sort(linesOfClients, (a, b) => int.Parse(a.Split(',')[0]).CompareTo(int.Parse(b.Split(',')[0])));

                // Перезаписуємо файл з відсортованими рядками та новими айді
                using (StreamWriter writer = new StreamWriter(accessFileOfClients.FilePath))
                {
                    int newId = 1;

                    foreach (string line in linesOfClients)
                    {
                        string[] parts = line.Split(',');
                        parts[0] = newId.ToString();
                        writer.WriteLine(string.Join(',', parts));
                        newId++;
                    }
                }
            }

        }
    }
}
