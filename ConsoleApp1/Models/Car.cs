namespace CarDealership.Models
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public Car(int id, string brand, int year, string model, string color, string condition, int price, int numberOfDoors)
            : base(id, brand, year, model, color, condition, price)
        {
            NumberOfDoors = numberOfDoors;
        }
    }
}
