namespace CarDealership.Models
{
    public class Motorcycle : Vehicle
    {
       
        public string MotorcycleType { get; set; }

        public Motorcycle(int id, string brand, int year, string model, string color, string condition, int price, string motorcycleType)
            : base(id, brand, year, model, color, condition, price)
        {
            MotorcycleType = motorcycleType;
        }
    }
}
