using CarDealership.MainFunctions.ClientFunctions;
using CarDealership.Models;
using CarDealership.Utils;

namespace CarDealership.MainFunctions.OrderF
{
    public class Order
    {

        private static int carrier;
        private static string selectedCarrierStr = "";
        private static string lineOfClient = "";
        private static int indexToDelete = -1;
        private static AccessFile accessFileOfClients = new("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");
        private static string[] linesOfClients = (string[])accessFileOfClients.Lines.Clone();
        static int TotalPrice = 0;

        public static void CreateOrder()
        {
            PrintClients.PrintAllClients();
            ChooseClientForOrder();
            ChooseTransportForClient();
            ChooseProviderForClient();
            ChooseCarrierForClient();
            WriteToFile();
        }
        private static void ChooseClientForOrder()
        {
            MenuText.BlueOutput("\nОбиріть клієнта з списку вище, який буде робити замовлення:\n");

            Console.Write("\nВведіть id клієнта: ");
            int idClient = Convert.ToInt32(Console.ReadLine());

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
                ChooseClientForOrder();
            }
            AccessFile accessFile = new("OrderDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
            string[] lines = accessFile.Lines;
            int idOrder = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;

            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{idOrder},{lineOfClient}");
            }

            MenuText.SuccessOutput($"Клієнт успішно обрайний.");
        }
        private static void ChooseTransportForClient()
        {
            Console.Write(MenuText.ChoosePrintForVehicle);
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
                ChooseTransportForClient();
            }
        }

        private static void ChooseProviderForClient()
        {
            AccessFile accessFileOfSelectedVehicle = new("SelectedVehicleDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
            string[] linesSelectedVehicle = (string[])accessFileOfSelectedVehicle.Lines.Clone();
            string lastLineSelectedVehicle = linesSelectedVehicle[linesSelectedVehicle.Length - 1];

            string[] valuesSelectedVehicle = lastLineSelectedVehicle.Split(',');
            TotalPrice = Convert.ToInt32(valuesSelectedVehicle[6]);

            var selectedproviderStr = "";
            Console.Write(MenuText.ChooseProvider);
            MenuText.OutputEnterNumOfFunc();
            int provider = Convert.ToInt32(Console.ReadLine());

            if (provider < 1 || provider > 3)
            {
                MenuText.ErrorOutputText("Значення введено не правильно!");
                ChooseProviderForClient();
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

                AccessFile accessFileToProvider = new("ProviderDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
                string[] linesProvider = accessFileToProvider.Lines;
                int idProvider = linesProvider.Length > 0 ? int.Parse(linesProvider[linesProvider.Length - 1].Split(',')[0]) + 1 : 1;

                using (StreamWriter writer = new StreamWriter(accessFileToProvider.FilePath, true))
                {
                    writer.WriteLine($"{idProvider},{selectedproviderStr}");
                }

                MenuText.SuccessOutput("Постачальник успішно обраний");
            }
        }
        private static void ChooseCarrierForClient()
        {
            Console.Write(MenuText.ChooseCarrier);
            MenuText.OutputEnterNumOfFunc();
            carrier = Convert.ToInt32(Console.ReadLine());

            if (carrier < 1 || carrier > 3)
            {
                MenuText.ErrorOutputText("Значення введено не правильно!");
                ChooseCarrierForClient();
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

                AccessFile accessFileToCarrier = new("CarrierDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
                string[] linesCarrier = accessFileToCarrier.Lines;
                int idCarrier = linesCarrier.Length > 0 ? int.Parse(linesCarrier[linesCarrier.Length - 1].Split(',')[0]) + 1 : 1;

                using (StreamWriter writer = new StreamWriter(accessFileToCarrier.FilePath, true))
                {
                    writer.WriteLine($"{idCarrier},{selectedCarrierStr}");
                }

                MenuText.SuccessOutput("Перевізник успішно обраний.\n Вітємо з покупкою!");
            }
        }

        private static void WriteToFile()
        {

            AccessFile accessFileToSoldOut = new("SoldOut.txt", "..\\..\\..\\MainFunctions\\OrderF");
            string[] linesSoldOut = accessFileToSoldOut.Lines!;
            int idSoldOut = linesSoldOut!.Length > 0 ? int.Parse(linesSoldOut[linesSoldOut.Length - 1].Split(',')[0]) + 1 : 1;

            string[] linesOrder = TextFileReader.GetLinesFromFile("OrderDB.txt", "..\\..\\..\\MainFunctions\\OrderF", idSoldOut - 1, 1);
            string[] linesVehicle = TextFileReader.GetLinesFromFile("SelectedVehicleDB.txt", "..\\..\\..\\MainFunctions\\OrderF", idSoldOut - 1, 1);
            string[] linesProvider = TextFileReader.GetLinesFromFile("ProviderDB.txt", "..\\..\\..\\MainFunctions\\OrderF", idSoldOut - 1, 1);
            string[] linesCarrier = TextFileReader.GetLinesFromFile("ProviderDB.txt", "..\\..\\..\\MainFunctions\\OrderF", idSoldOut - 1, 1);

            string orderStr = $"{linesOrder[0].Split(',')[1]},{linesOrder[0].Split(',')[2]},{linesOrder[0].Split(',')[3]}";         
            string vehicleStr = $"{linesVehicle[0].Split(',')[1]},{linesVehicle[0].Split(',')[2]},{linesVehicle[0].Split(',')[3]},{linesVehicle[0].Split(',')[6]}";
            string providerStr = $"{linesProvider[0].Split(',')[1]}";   
            string carrierStr = $"{linesCarrier[0].Split(',')[1]}";

            using (StreamWriter writer = new StreamWriter(accessFileToSoldOut.FilePath!, true))
            {
                writer.WriteLine($"{idSoldOut},{orderStr}, {vehicleStr}, {providerStr}, {carrierStr}, {TotalPrice}");
            }

            List<string> newLines = linesOfClients.ToList();
            newLines.RemoveAt(indexToDelete);
            linesOfClients = newLines.ToArray();

            using (StreamWriter writer = new StreamWriter(accessFileOfClients.FilePath!))
            {
                for (int i = linesOfClients.Length - 1; i >= 0; i--)
                {
                    writer.WriteLine(linesOfClients[i]);
                }
            }

            List<Client> clients = ClientImporter.ImportClientsFromFileForPrint(linesOfClients);

            clients = clients.OrderBy(client => client.Id).ToList();

            using (StreamWriter sw = new StreamWriter(accessFileOfClients.FilePath!))
            {
                foreach (Client client in clients)
                {
                    string line = $"{client.Id},{client.Name},{client.Phone},{client.Email},{client.PreferredBrand},{client.MinPrice},{client.MaxPrice},{client.MinYear},{client.MaxYear}";
                    sw.WriteLine(line);
                }
            }
            Array.Sort(linesOfClients, (a, b) => int.Parse(a.Split(',')[0]).CompareTo(int.Parse(b.Split(',')[0])));

            using (StreamWriter writer = new StreamWriter(accessFileOfClients.FilePath!))
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
