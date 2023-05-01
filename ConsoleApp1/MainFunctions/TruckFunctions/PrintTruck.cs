using CarDealership.Models;
using System.Text;
using ConsoleTables;

namespace CarDealership.MainFunctions.TruckFunctions
{
    public class PrintTruck
    {
        static public void PrintAllTrucks()
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Truck> allTrucks = new List<Truck>();

            AccessFile accessFileOfTruck = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            string[] linesTrucks = accessFileOfTruck.Lines;

            foreach (string line in linesTrucks)
            {
                string[] values = line.Split(',');

                int id = int.Parse(values[0]);
                string brand = values[1] != "0" ? values[1] : "Даних немає";
                int year = values[2] != "0" ? int.Parse(values[2]) : 0;
                string model = values[3] != "0" ? values[3] : "Даних немає";
                string color = values[4] != "0" ? values[4] : "Даних немає";
                string condition = values[5] != "0" ? values[5] : "Даних немає";
                int price = values[6] != "0" ? int.Parse(values[6]) : 0;
                int numberOfWheels = values[7] != "0" ? int.Parse(values[7]) : 0;
                int loadCapacity = values[8] != "0" ? int.Parse(values[8]) : 0;

                Truck newTruck = new Truck(id, brand, year, model, color, condition, price, numberOfWheels, loadCapacity);

                allTrucks.Add(newTruck);
            }

            var table = new ConsoleTable("ID", "Бренд", "Рік випуску", "Модель", "Колір", "Стан", "Ціна", "Кількість коліс", "Грузопідйомність(У тоннах)");

            foreach (Truck truck in allTrucks)
            {
                AddTruckRowToTable(truck, table);
            }
            Console.Write(table.ToString());
        }

        public static void AddTruckRowToTable(Truck truck, ConsoleTable table)
        {
            table.AddRow(
                truck.Id,
                truck.Brand,
                truck.Year,
                truck.Model,
                truck.Color,
                truck.Condition,
                truck.Price,
                truck.NumberOfWheels,
                truck.LoadCapacity
            );
        }
    }
}