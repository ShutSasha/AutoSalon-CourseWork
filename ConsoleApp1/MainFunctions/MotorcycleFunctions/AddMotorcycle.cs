using CarDealership.Utils;
using CarDealership.ValidatorsMethods;

namespace CarDealership.MainFunctions
{
    internal class AddMotorcycle
    {
        public static void AddMotorcycleToFileMethod()
        {

            InputValidators.EnterTheCharacteristicsOfTheVehicle(out string brand, out int year, out string model, out string color, out string condition, out int price);

            Console.Write("Введіть тип мотоцикла(sport, cruiser): ");
            string motorcycleType = InputValidators.BikeType();

            AccessFile accessFile = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            string[] lines = accessFile.Lines;
            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;

            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{id},{brand},{year},{model},{color},{condition},{price},{motorcycleType}");
            }

           MenuText.SuccessOutput("\nMotorcycle added to file successfully!");
        }
    }
}
