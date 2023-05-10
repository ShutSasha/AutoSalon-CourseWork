using CarDealership.Utils;
using CarDealership.ValidatorsMethods;
using System.Text;

namespace CarDealership.MainFunctions.ClientFunctions
{
    public class AddClient
    {
        static public void AddClientToFileMethod()
        {
            
            string? username = InputValidators.FullNameInputValidator();

            string? phone = InputValidators.GetValidPhoneNumber();

            string? email = InputValidators.EmailInputValidator();

            string? PreferredBrand = InputValidators.BrandInputValidator();

            int priceFrom = InputValidators.PriceInputFromTo("Enter the price from: ", 0, 3000000);

            int priceTo = InputValidators.PriceInputFromTo("Enter the price to: ", 1, 3000000);
            if (priceFrom > priceTo) (priceFrom, priceTo) = (priceTo, priceFrom);

            int yearFrom = InputValidators.YearInputFromTo("Enter the year from: ", 1920, DateTime.Now.Year);

            int yearTo = InputValidators.YearInputFromTo("Enter the year To: ", 1920, DateTime.Now.Year);
            if (yearFrom > yearTo) (yearFrom, yearTo) = (yearTo, yearFrom);

            AccessFile accessFile = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");
            string[] lines = accessFile.Lines;
            int id = lines.Length > 0 ? int.Parse(lines[lines.Length - 1].Split(',')[0]) + 1 : 1;

            using (StreamWriter writer = new StreamWriter(accessFile.FilePath, true))
            {
                writer.WriteLine($"{id},{username},{phone},{email},{PreferredBrand},{priceFrom},{priceTo},{yearFrom},{yearTo}");
            }

            MenuText.SuccessOutput("\nClient added to file successfully!");
        }
    }
}