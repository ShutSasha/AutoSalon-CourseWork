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
        private static void DeleteVehicleMethod(string filePath, string vehicleType)
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

            Console.Write("\nВведіть id транспорту, який хочете видалити: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());

            string[] lines = File.ReadAllLines(filePath);

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
                deleteAndWriteChangesToFile(lines, indexToDelete, filePath);

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
            DeleteVehicleMethod(accessFile.FilePath, "car");
        }

        public static void DeleteMotorcycle()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            DeleteVehicleMethod(accessFile.FilePath, "motorcycle");
        }

        public static void DeleteTruck()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            DeleteVehicleMethod(accessFile.FilePath, "truck");
        }

        private static void DeleteForPurchasedVehicle(string filePath, string vehicleType)
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

            Console.Write("\nВведіть id транспорту, який хочете обрати: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());

            string[] lines = File.ReadAllLines(filePath);

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
                deleteAndWriteChangesToFile(lines, indexToDelete, filePath);

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
            DeleteForPurchasedVehicle(accessFile.FilePath, "car");
        }

        public static void DeleteMotorcycleForPurchased()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            DeleteForPurchasedVehicle(accessFile.FilePath, "motorcycle");
        }

        public static void DeleteTruckForPurchased()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            DeleteForPurchasedVehicle(accessFile.FilePath, "truck");
        }
    }
}