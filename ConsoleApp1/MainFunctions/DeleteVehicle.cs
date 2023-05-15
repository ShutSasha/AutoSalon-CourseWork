using CarDealership.Utils;

namespace CarDealership.MainFunctions
{
    public class DeleteVehicle
    {
     
        private static void deleteAndWriteChangesToFile(string[] lines, int indexToDelete, string filePath)
        {
            List<string> newLines = lines.ToList();
            newLines.RemoveAt(indexToDelete);
            lines = newLines.ToArray();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = lines.Length - 1; i >= 0; i--)
                {
                    writer.WriteLine(lines[i]);
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath))
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
        }
       
      

        private static int ValidateIdInput(string[] lines, string prompt)
        {
            while (true)
            {
                Console.Write($"\nВведіть id транспорту, який хочете {prompt}: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int id) || id <= 0)
                {
                    MenuText.ErrorOutputText("Неправильний ввід. Введіть додатнє ціле число.");
                }
                else
                {
                    bool idExists = false;
                    foreach (string line in lines)
                    {
                        string[] data = line.Split(',');
                        if (data[0] == input)
                        {
                            idExists = true;
                            break;
                        }
                    }
                    if (idExists)
                    {
                        return id;
                    }
                    else
                    {
                        MenuText.ErrorOutputText("Транспорт з введеним id не знайдено. Спробуйте ще раз");
                    }
                }
            }
        }

        private static void DeleteForPurchasedVehicle(AccessFile AccessFilePath, string vehicleType, AutoSalon salon)
        {
            if (!(AccessFilePath.Lines.Length > 0))
            {
                MenuText.ErrorOutputText($"\n{vehicleType} не знайдено в автосалоні.");
                StartTheProgram startProgmra = new(salon);
                startProgmra.Start();
            }
            var numElements = 0;

            switch (vehicleType)
            {
                case "car":
                    salon.PrintCars();
                    numElements = 7;
                    break;
                case "motorcycle":
                    salon.PrintMotorcycle();
                    numElements = 7;
                    break;
                case "truck":
                    salon.PrintTruck();
                    numElements = 8;
                    break;
            }

            int idToDelete = ValidateIdInput(AccessFilePath.Lines, "обрати");

            string[] lines = File.ReadAllLines(AccessFilePath.FilePath);

            int indexToDelete = -1;
            string lineofVehicle = "";
            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                int id = int.Parse(values[0]);

                if (id == idToDelete)
                {
                    indexToDelete = i;

                    for (int j = 1; j < numElements; j++)
                    {
                        lineofVehicle += values[j];

                        if (j < numElements)
                        {
                            lineofVehicle += ",";
                        }
                    }
                    lineofVehicle = lineofVehicle.Substring(0, lineofVehicle.Length - 1);
                    break;
                }
            }

            AccessFile accessFile = AccessFile.GetAccessToFile("SelectedVehicleDB.txt", "..\\..\\..\\MainFunctions\\OrderF");
            string[] linesOfSelectedVehicle = accessFile.Lines;
            int idSelectedVehicle = linesOfSelectedVehicle.Length > 0 ? int.Parse(linesOfSelectedVehicle[linesOfSelectedVehicle.Length - 1].Split(',')[0]) + 1 : 1;

            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{idSelectedVehicle},{lineofVehicle}");
            }

            if (indexToDelete >= 0)
            {
                deleteAndWriteChangesToFile(lines, indexToDelete, AccessFilePath.FilePath);

                MenuText.SuccessOutput($"\nТранспорт з айді {idToDelete} успішно обраний з файлу.");
            }
            else
            {
                MenuText.ErrorOutputText($"\nТранспорт з айді {idToDelete} не знайдено!.");
            }
        }

        public static void DeleteCarForPurchased(AutoSalon salon)
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            DeleteForPurchasedVehicle(accessFile, "car", salon);
        }

        public static void DeleteMotorcycleForPurchased(AutoSalon salon)
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            DeleteForPurchasedVehicle(accessFile, "motorcycle", salon);
        }

        public static void DeleteTruckForPurchased(AutoSalon salon)
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            DeleteForPurchasedVehicle(accessFile, "truck", salon);
        }
    }
}