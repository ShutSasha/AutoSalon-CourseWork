using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.MainFunctions.MotorcycleFunctions
{
    public class PrintMotorcycle
    {
        static public void PrintAllMotorcycles()
        {
            List<Motorcycle> allMotorcycles = new List<Motorcycle>();

            AccessFile accessFileOfMotorcycle = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            string[] linesMotorcycles = accessFileOfMotorcycle.Lines;

            foreach (string line in linesMotorcycles)
            {
                string[] values = line.Split(',');

                int id = int.Parse(values[0]);
                string brand = values[1] != "0" ? values[1] : "Даних немає";
                int year = values[2] != "0" ? int.Parse(values[2]) : 0;
                string model = values[3] != "0" ? values[3] : "Даних немає";
                string color = values[4] != "0" ? values[4] : "Даних немає";
                string condition = values[5] != "0" ? values[5] : "Даних немає";
                int price = values[6] != "0" ? int.Parse(values[6]) : 0;
                string motorcycleType = values[7] != "0" ? values[7] : "Даних немає";

                Motorcycle newMotorcycle = new Motorcycle(id, brand, year, model, color, condition, price, motorcycleType);

                allMotorcycles.Add(newMotorcycle);
            }

            foreach (Motorcycle motorcycle in allMotorcycles)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine($"Id:{motorcycle.Id}, Бренд: {motorcycle.Brand}, Рік випуску: {motorcycle.Year},\nМодель: {motorcycle.Model}, Колір: {motorcycle.Color}, Стан: {motorcycle.Condition},\nЦіна: {motorcycle.Price}, Тип мотоцикла: {motorcycle.MotorcycleType} \n---------------------------------------------------------------------");
            }
        }
    }
}