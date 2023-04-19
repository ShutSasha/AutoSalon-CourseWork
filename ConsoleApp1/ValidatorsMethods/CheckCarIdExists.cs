using CarDealership.Models;

namespace CarDealership.ValidatorsMethods
{
    internal class CheckIdExists
    {

        public static bool CheckIdExistsVehicle<T>(List<T> items, int id) where T : Vehicle
        {
            bool idExists = false;

            foreach (T item in items)
            {
                if (item.Id == id)
                {
                    idExists = true;
                    break;
                }
            }

            return idExists;
        }

        public static bool CheckClientExistID(List<Client> allClients, int id)
        {
            bool idExists = false;

            foreach (Client client in allClients)
            {
                if (client.Id == id)
                {
                    idExists = true;
                    break;
                }
            }

            return idExists;
        }
    }
}
