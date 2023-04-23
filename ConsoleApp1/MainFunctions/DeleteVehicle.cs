using CarDealership.MainFunctions.CarFunctions;
using CarDealership.MainFunctions.MotorcycleFunctions;
using CarDealership.MainFunctions.TruckFunctions;

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
            
            Console.Write("\nВведіть id транспорту, який хочете видалити");
            int idToDelete = Convert.ToInt32(Console.ReadLine());
            // Зчитуємо усі рядки з файлу
            string[] lines = File.ReadAllLines(filePath);

            // Шукаємо індекс рядка, який потрібно видалити
            int indexToDelete = -1;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(idToDelete.ToString()))
                {
                    indexToDelete = i;
                    break;
                }
            }

            // Якщо рядок знайдено, видаляємо його та записуємо зміни в файл
            if (indexToDelete >= 0)
            {
                string[] updatedLines = new string[lines.Length - 1];
                for (int i = 0, j = 0; i < lines.Length; i++)
                {
                    if (i != indexToDelete)
                    {
                        updatedLines[j] = lines[i];
                        j++;
                    }
                }
                File.WriteAllLines(filePath, updatedLines);
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
    }
}
