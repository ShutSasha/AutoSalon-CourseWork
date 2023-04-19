using CarDealership.Models;

namespace CarDealership.ValidatorsMethods
{
    internal class CheckCarIdExists
    {


        public static bool CheckCarIdExistsMethod(List<Car> allCars, int id)
        {
            bool idExists = false;

            foreach (Car car in allCars)
            {
                if (car.Id == id)
                {
                    idExists = true;
                    break;
                }
            }

            return idExists;
        }


    }
}
