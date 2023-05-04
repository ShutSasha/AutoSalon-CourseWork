using CarDealership.Utils;
using CarDealership.ValidatorsMethods;

namespace CarDealership.MainFunctions.TruckFunctions
{
    internal class AddTruck
    {
        public static void AddTruckToFileMethod()
        {

            InputValidators.EnterTheCharacteristicsOfTheVehicle(out string brand, out int year, out string model, out string color, out string condition, out int price);

            int numberOfWheels = InputValidators.NumberOfWheelsInputValidator();

            int loadCapacity = InputValidators.LoadCapacityInputValidator();

            AccessFile accessFile = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            string[] lines = accessFile.Lines;
            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;

            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{id},{brand},{year},{model},{color},{condition},{price},{numberOfWheels},{loadCapacity}");
            }
            MenuText.SuccessOutput("\nTruck added to file successfully!");
        }
    }
}
