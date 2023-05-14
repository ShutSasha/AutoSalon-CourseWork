//using CarDealership.Utils;
//using CarDealership.ValidatorsMethods;
//using System.Text;

//namespace CarDealership.MainFunctions.ClientFunctions
//{
//    public class AddClient
//    {
//        static public void AddClientToFileMethod()
//        {

//            string? username = InputValidators.FullNameInputValidator();

//            string? phone = InputValidators.GetValidPhoneNumber();

//            string? email = InputValidators.EmailInputValidator();

//            string? PreferredBrand = InputValidators.BrandInputValidator();

//            int priceFrom = InputValidators.PriceInputFromTo("Enter the price from: ", 0, 3000000);

//            int priceTo = InputValidators.PriceInputFromTo("Enter the price to: ", 1, 3000000);
//            if (priceFrom > priceTo) (priceFrom, priceTo) = (priceTo, priceFrom);
