using CarDealership.Models;
using CarDealership.Utils;
using ConsoleTables;

namespace CarDealership.SecondaryFunctions
{
    public class Print
    {
        public static void AddVehicleToTable(Vehicle vehicle, ConsoleTable table)
        {
            object[] values = new object[]
            {
                vehicle.Id,
                vehicle.Brand,
                vehicle.Year,
                vehicle.Model,
                vehicle.Color,
                vehicle.Condition,
                vehicle.Price
            };
            if (vehicle is Truck truck)
            {
                values = values.Append(truck.NumberOfWheels).ToArray();
                values = values.Append(truck.LoadCapacity).ToArray();
            }
            else if (vehicle is Car car)
            {
                values = values.Append(car.NumberOfDoors).ToArray();
            }
            else
            {
                Motorcycle? bike = vehicle as Motorcycle;
                values = values.Append(bike!.MotorcycleType).ToArray();
            }
            table.AddRow(values);
        }
        public static void PrintMatchingVehicle(List<Vehicle> matchingVehicals, string vehicleTypeName, string[] vehicleHeader)
        {
            if (matchingVehicals.Count > 0)
            {
                Console.WriteLine($"\nMatching {vehicleTypeName}:");
                var table = new ConsoleTable(vehicleHeader);
                foreach (var vehicle in matchingVehicals)
                {
                    AddVehicleToTable(vehicle, table);
                }

                Console.Write(table.ToString());
            }

            else
            {
                MenuText.OutputErrorOfNoMatchingVehicle($"{vehicleTypeName}");
            }
        }
    }
}