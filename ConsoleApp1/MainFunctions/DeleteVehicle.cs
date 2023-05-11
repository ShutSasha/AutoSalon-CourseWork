using CarDealership.MainFunctions.CarFunctions;
using CarDealership.MainFunctions.MotorcycleFunctions;
using CarDealership.MainFunctions.TruckFunctions;
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
        private static void DeleteVehicleMethod(AccessFile AccessFilePath, string vehicleType)
        {
            switch (vehicleType)
            {
                case "car":
                    PrintCars.PrintCarsMethod();
                    break;
                case "motorcycle":
                    PrintMotorcycle.PrintAllMotorcycles();
                    break;
                case "truck":
                    PrintTruck.PrintAllTrucks();
                    break;
            }


            int idToDelete = ValidateIdInput(AccessFilePath.Lines, "видалити");

            string[] lines = File.ReadAllLines(AccessFilePath.FilePath);

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

            if (indexToDelete >= 0)
            {
                deleteAndWriteChangesToFile(lines, indexToDelete, AccessFilePath.FilePath);

                MenuText.SuccessOutput($"\nЕлемент з айді {idToDelete} успішно видалений з файлу.");
            }
            else
            {
                MenuText.ErrorOutputText($"\nТранспорт з айді {idToDelete} не знайдено!.");
            }
        }

        public static void DeleteCar()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            DeleteVehicleMethod(accessFile, "car");
        }

        public static void DeleteMotorcycle()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            DeleteVehicleMethod(accessFile, "motorcycle");
        }

        public static void DeleteTruck()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            DeleteVehicleMethod(accessFile, "truck");
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

        private static void DeleteForPurchasedVehicle(AccessFile AccessFilePath, string vehicleType)
        {
            var numElements = 0;
            switch (vehicleType)
            {
                case "car":
                    PrintCars.PrintCarsMethod();
                    numElements = 7;
                    break;
                case "motorcycle":
                    PrintMotorcycle.PrintAllMotorcycles();
                    numElements = 7;
                    break;
                case "truck":
                    PrintTruck.PrintAllTrucks();
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

        public static void DeleteCarForPurchased()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            DeleteForPurchasedVehicle(accessFile, "car");
        }

        public static void DeleteMotorcycleForPurchased()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            DeleteForPurchasedVehicle(accessFile, "motorcycle");
        }

        public static void DeleteTruckForPurchased()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            DeleteForPurchasedVehicle(accessFile, "truck");
        }
    }
}