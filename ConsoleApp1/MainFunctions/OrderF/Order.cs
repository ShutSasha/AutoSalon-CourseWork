using CarDealership.MainFunctions.ClientFunctions;
using CarDealership.Models;
using CarDealership.Utils;

namespace CarDealership.MainFunctions.OrderF
{
    internal class Order
    {
        public static void CreateOrder()
        {

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
            var lineOfClient = "";
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
                        lineOfClient = $"{values[1]},{values[2]},{values[3]},{values[4]},{values[5]},{values[6]},{values[7]},{values[8]}";
                        break;
                    }
                }

                if (indexToDelete == -1)
                {
                    Console.WriteLine($"Клієнта з айді {idClient} не знайдено. Спробуйте ще раз");
                    chooseClient();
                }
            }

            AccessFile accessFile = AccessFile.GetAccessToFile("OrderDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
            string[] lines = accessFile.Lines;
            int idOrder = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;

            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{idOrder},{lineOfClient}");
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
                MenuText.OutputEnterNumOfFunc();
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

            AccessFile accessFileOfSelectedVehicle = AccessFile.GetAccessToFile("SelectedVehicleDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
            string[] linesSelectedVehicle = accessFileOfClients.Lines;
            string lastLineSelectedVehicle = linesSelectedVehicle[linesSelectedVehicle.Length - 1];

            // Розділяємо рядок на окремі значення
            string[] valuesSelectedVehicle = lastLineSelectedVehicle.Split(',');
            int TotalPrice = lastLineSelectedVehicle[lastLineSelectedVehicle.Length - 1];

            int provider;
            bool providerBool = false;
            chooseProvider();
            void chooseProvider()
            {
                var selectedproviderStr = "";
                Console.Write("Обиріть постачальника нижче:\n" +
                                "1. Амереканський - найдорожчий та найбільш якісний транспорт (+1000$ до вартості транспорту)\n" +
                                "2. Європейський - якісний транспорт та найдійний постачальник (+700$ до вартості транспорту)\n" +
                                "3. Постачальник з Японії - якісний транспорт (+500$ до вартості транспорту)");
                provider = Convert.ToInt32(Console.ReadLine());

                if (provider < 1 || provider > 3)
                {
                    MenuText.ErrorOutputText("Значення введено не правильно!");
                    chooseProvider();
                }
                else
                {
                    switch (provider)
                    {
                        case 1:
                            TotalPrice += 1000;
                            selectedproviderStr = "Амереканський";
                            break;
                        case 2:
                            TotalPrice += 700;
                            selectedproviderStr = "Європейський";
                            break;
                        case 3:
                            TotalPrice += 500;
                            selectedproviderStr = "Японський";
                            break;
                        default:
                            break;
                    }

                    AccessFile accessFileToProvider = AccessFile.GetAccessToFile("ProviderDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
                    string[] linesProvider = accessFileToProvider.Lines;
                    int idProvider = linesProvider.Length > 0 ? int.Parse(linesProvider[linesProvider.Length - 1].Split(',')[0]) + 1 : 1;

                    using (StreamWriter writer = new StreamWriter(accessFileToProvider.FilePath, true))
                    {
                        writer.WriteLine($"{idProvider},{selectedproviderStr}");
                    }

                    MenuText.SuccessOutput("Постачальник успішно обраний");
                    providerBool = true;
                }
            }
            int carrier;
            bool carrierBool = false;
            chooseCarrier();
            void chooseCarrier()
            {
                var selectedCarrierStr = "";
                Console.Write("Обиріть перевізника нижче:\n" +
                                "1. Швидкий (+1000$ до загальної вартості)\n" +
                                "2. Із середньою швидкістю (+700$ до загальної вартості)\n" +
                                "3. Повільний (+500$ до загальної вартості)");
                carrier = Convert.ToInt32(Console.ReadLine());

                if (carrier < 1 || carrier > 3)
                {

                    MenuText.ErrorOutputText("Значення введено не правильно!");
                    chooseCarrier();
                }
                else
                {
                    switch (carrier)
                    {
                        case 1:
                            TotalPrice += 1000;
                            selectedCarrierStr = "Швидкий";
                            break;
                        case 2:
                            TotalPrice += 700;
                            selectedCarrierStr = "Із середньою швидкістю";
                            break;
                        case 3:
                            TotalPrice += 500;
                            selectedCarrierStr = "Повільний";
                            break;
                        default:
                            break;
                    }

                    AccessFile accessFileToCarrier = AccessFile.GetAccessToFile("CarrierDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
                    string[] linesCarrier = accessFileToCarrier.Lines;
                    int idCarrier = linesCarrier.Length > 0 ? int.Parse(linesCarrier[linesCarrier.Length - 1].Split(',')[0]) + 1 : 1;

                    using (StreamWriter writer = new StreamWriter(accessFileToCarrier.FilePath, true))
                    {
                        writer.WriteLine($"{idCarrier},{selectedCarrierStr}");
                    }

                    MenuText.SuccessOutput("Перевізник успішно обраний.\n Вітємо з покупкою!");
                    carrierBool = true;
                }
            }

            bool confirmOrder = false;
            if (providerBool && carrierBool)
            {
                confirmOrder = true;
            }
            if (confirmOrder)
            {

                // soldOut
                AccessFile accessFileToSoldOut = AccessFile.GetAccessToFile("SoldOut.txt", "..\\..\\..\\MainFunctions\\OrderF");
                string[] linesSoldOut = accessFileToSoldOut.Lines;
                int idSoldOut = linesSoldOut.Length > 0 ? int.Parse(linesSoldOut[linesSoldOut.Length - 1].Split(',')[0]) + 1 : 1;

                // orderDB or client
                AccessFile accessFileOrderDB = AccessFile.GetAccessToFile("OrderDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
                string[] linesOrder = accessFileOrderDB.Lines;
                string[] lineOrder = linesOrder[idSoldOut - 1].Split(',');
                string orderStr = $"{lineOrder[1]}, {lineOrder[2]}, {lineOrder[3]} ";

                // vehicle

                AccessFile accessFileVehicle = AccessFile.GetAccessToFile("SelectedVehicleDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
                string[] linesVehicle = accessFileVehicle.Lines;
                string[] lineVehicle = linesVehicle[idSoldOut - 1].Split(',');
                string vehicleStr = $"{lineVehicle[1]}, {lineVehicle[2]}, {lineVehicle[3]}, {lineVehicle[6]}";

                // provider

                AccessFile accessFileToProvider = AccessFile.GetAccessToFile("ProviderDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
                string[] linesProvider = accessFileToProvider.Lines;
                string[] lineProvider = linesProvider[idSoldOut - 1].Split(',');
                string providerStr = $"{lineProvider[1]}";

                // carrier

                AccessFile accessFileToCarrier = AccessFile.GetAccessToFile("CarrierDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
                string[] linesCarrier = accessFileToCarrier.Lines;
                string[] lineCarrier = linesCarrier[idSoldOut - 1].Split(',');
                string carrierStr = $"{lineProvider[1]}";

                using (StreamWriter writer = new StreamWriter(accessFileToSoldOut.FilePath, true))
                {
                    writer.WriteLine($"{idSoldOut},{orderStr}, {vehicleStr}, {providerStr}, {carrierStr}");
                }

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
