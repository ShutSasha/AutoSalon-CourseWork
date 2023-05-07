using CarDealership.MainFunctions.CarFunctions;
using CarDealership.MainFunctions.MotorcycleFunctions;
using CarDealership.MainFunctions.OrderF;
using CarDealership.MainFunctions.TruckFunctions;
using System.Security.AccessControl;

namespace CarDealership.MainFunctions
{
    internal class DeleteVehicle
    {
        public static void DeleteVehicleMethod(string filePath, string vehicleType)
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
            // Зчитуємо усі рядки з файлу
            string[] lines = File.ReadAllLines(filePath);

            // Шукаємо індекс рядка, який потрібно видалити
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

            // Якщо рядок знайдено, видаляємо його та записуємо зміни в файл
            if (indexToDelete >= 0)
            {
                // Видаляємо рядок з файлу
                List<string> newLines = lines.ToList();
                newLines.RemoveAt(indexToDelete);
                lines = newLines.ToArray();

                // Перезаписуємо файл
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


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nЕлемент з айді {idToDelete} успішно видалений з файлу.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nТранспорт з айді {idToDelete} не знайдено!.");
                Console.ResetColor();
            }
        }

        // Метод видалення автомобіля
        public static void DeleteCar()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            DeleteVehicleMethod(accessFile.FilePath, "car");
        }

        // Метод видалення мотоцикла
        public static void DeleteMotorcycle()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            DeleteVehicleMethod(accessFile.FilePath, "motorcycle");
        }

        // Метод видалення грузовика
        public static void DeleteTruck()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            DeleteVehicleMethod(accessFile.FilePath, "truck");
        }

        public static void DeleteForPurchasedVehicle(string filePath, string vehicleType)
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
            // Зчитуємо усі рядки з файлу
            string[] lines = File.ReadAllLines(filePath);

            // Шукаємо індекс рядка, який потрібно видалити
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


            // Якщо рядок знайдено, видаляємо його та записуємо зміни в файл
            if (indexToDelete >= 0)
            {
                // Видаляємо рядок з файлу
                List<string> newLines = lines.ToList();
                newLines.RemoveAt(indexToDelete);
                lines = newLines.ToArray();

                // Перезаписуємо файл
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


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nТранспорт з айді {idToDelete} успішно обраний з файлу.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nТранспорт з айді {idToDelete} не знайдено!.");
                Console.ResetColor();
            }
        }
    
            // Метод видалення автомобіля
            public static void DeleteCarForPurchased()
            {
                AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
                DeleteForPurchasedVehicle(accessFile.FilePath, "car");
            }

            // Метод видалення мотоцикла
            public static void DeleteMotorcycleForPurchased()
            {
                AccessFile accessFile = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
                DeleteForPurchasedVehicle(accessFile.FilePath, "motorcycle");
            }

            // Метод видалення грузовика
            public static void DeleteTruckForPurchased()
            {
                AccessFile accessFile = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
                DeleteForPurchasedVehicle(accessFile.FilePath, "truck");
            }
        }
    
}

//for (int i = 0; i < lines.Length; i++)
//{
//    string[] values = lines[i].Split(',');
//    int numElements = values.Length;

//    if (lines[i].StartsWith(idToDelete.ToString()))
//    {
//        indexToDelete = i;
//        lineofVehicle = "";

//        for (int j = 1; j < numElements; j++)
//        {
//            lineofVehicle += values[j];

//            if (j < numElements)
//            {
//                lineofVehicle += ",";
//            }
//        }

//        break;
//    }
//}

//AccessFile accessFile = AccessFile.GetAccessToFile("OrderDB.txt", "..\\..\\..\\MainFunctions\\OrderF");

//using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
//{
//    writer.Write($"{lineofVehicle}");
//}