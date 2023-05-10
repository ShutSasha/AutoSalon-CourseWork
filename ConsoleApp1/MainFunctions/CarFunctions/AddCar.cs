using CarDealership.Utils;
using CarDealership.ValidatorsMethods;

namespace CarDealership.MainFunctions.CarFunctions
{
    internal class AddCar
    {
        static public void AddCarToFileMethod()
        {
           
            InputValidators.EnterTheCharacteristicsOfTheVehicle(out string brand, out int year, out string model, out string color, out string condition, out int price);

            int numberOfDoors = InputValidators.NumberOfDoorsInputValidator();
            
            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[]? lines = accessFile.Lines;

            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;

            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{id},{brand},{year},{model},{color},{condition},{price},{numberOfDoors}");
            }

            MenuText.SuccessOutput("\nCar added to file successfully!");
        }
    }
}