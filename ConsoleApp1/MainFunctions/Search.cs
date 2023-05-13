using CarDealership.Models;
using CarDealership.Utils;
using CarDealership.ValidatorsMethods;

namespace CarDealership.MainFunctions
{
    public class Search
    {
       
        public static void SearchMethod()
        {

            AccessFile accessFileOfCars = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[] linesOfCars = accessFileOfCars.Lines;

            AccessFile accessFileOfBikes = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            string[] linesOfBikes = accessFileOfBikes.Lines;

            AccessFile accessFileOfTrucks = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            string[] linesOfTrucks = accessFileOfTrucks.Lines;

            List<Car> matchingCars = new List<Car>();
            List<Motorcycle> matchingBikes = new List<Motorcycle>();
            List<Truck> matchingTrucks = new List<Truck>();

            string brand = InputValidators.BrandInputValidator(true);

            int yearFrom = InputValidators.YearInputFromTo("Enter the year from: ", 1920, DateTime.Now.Year, true);

            int yearTo = InputValidators.YearInputFromTo("Enter the year To: ", 1920, DateTime.Now.Year, true);
            if (yearFrom > yearTo) (yearFrom, yearTo) = (yearTo, yearFrom);

            string model = InputValidators.ModelInputValidator(true);

            string color = InputValidators.ColorInputValidator(true);

            string condition = InputValidators.ConditionInputValidator(true);

            int priceFrom = InputValidators.PriceInputFromTo("Enter the price from: ", 0, 3000000, true);

            int priceTo = InputValidators.PriceInputFromTo("Enter the price to: ", 1, 3000000, true);
            if (priceFrom > priceTo) (priceFrom, priceTo) = (priceTo, priceFrom);
           

            foreach (string line in linesOfCars)
            {
                string[] fields = line.Split(',');
                Car car = new Car(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), int.Parse(fields[7]));


                if (CheckOfMatchingVehicle(car))
                {
                    matchingCars.Add(car);
                }
            }

            Print.PrintMatchingVehicle(matchingCars.ConvertAll(list => (Vehicle)list), "cars", MenuText.carHeader);
            
            foreach (string line in linesOfBikes)
            {
                string[] fields = line.Split(',');
                Motorcycle bike = new Motorcycle(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), fields[7]);


                if (CheckOfMatchingVehicle(bike))
                {
                    matchingBikes.Add(bike);
                }
            }

            Print.PrintMatchingVehicle(matchingBikes.ConvertAll(list => (Vehicle)list), "bikes", MenuText.bikeHeader);

            foreach (string line in linesOfTrucks)
            {
                string[] fields = line.Split(',');
                Truck truck = new Truck(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), fields[3], fields[4], fields[5], int.Parse(fields[6]), int.Parse(fields[7]), int.Parse(fields[8]));


                if (CheckOfMatchingVehicle(truck))
                {
                    matchingTrucks.Add(truck);
                }
            }

            Print.PrintMatchingVehicle(matchingTrucks.ConvertAll(list => (Vehicle)list), "trucks", MenuText.truckHeader);

            bool CheckOfMatchingVehicle(Vehicle vehicle)
            {
                bool check = false;
                if ((brand == "" || vehicle.Brand.ToLower() == brand.ToLower())
                 && (yearFrom == 0 || yearFrom == -1 || vehicle.Year >= yearFrom)
                 && (yearTo == 0 || yearTo == -1 || vehicle.Year <= yearTo)
                 && (model == "" || vehicle.Model == model)
                 && (color == "" || vehicle.Color == color)
                 && (condition == "" || vehicle.Condition == condition)
                 && (priceFrom == 0 || vehicle.Price >= priceFrom)
                 && (priceTo == 0 || vehicle.Price <= priceTo))
                {
                    check = true;
                }

                return check;
            }
        }
    }
}
