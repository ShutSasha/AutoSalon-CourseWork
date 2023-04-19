using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Motorcycle : Vehicle
    {
        public int NumberOfWheels { get; set; }
        public string MotorcycleType { get; set; }

        public Motorcycle(int id, string brand, int year, string model, string color, string condition, int price, int numberOfWheels, string motorcycleType)
            : base(id, brand, year, model, color, condition, price)
        {
            NumberOfWheels = numberOfWheels;
            MotorcycleType = motorcycleType;
        }
    }
}
