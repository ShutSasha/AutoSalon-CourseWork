using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public class Truck : Vehicle
    {
        public int NumberOfWheels { get; set; }
        public int LoadCapacity { get; set; }

        public Truck(int id, string brand, int year, string model, string color, string condition, int price, int numberOfWheels, int loadCapacity)
            : base(id, brand, year, model, color, condition, price)
        {
            NumberOfWheels = numberOfWheels;
            LoadCapacity = loadCapacity;
        }
    }
}
