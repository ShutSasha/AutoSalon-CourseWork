﻿using System.Text;
using CarDealership.Models;

namespace CarDealership.MainFunctions.CarFunctions
{
    internal class PrintCars
    {
        static public void PrintCarsMethod()
        {
            List<Car> allCars = new List<Car>();
            Console.OutputEncoding = Encoding.UTF8;

            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[] lines = accessFile.Lines;

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                int id = int.Parse(values[0]);
                string brand = values[1];
                int year = int.Parse(values[2]);
                string model = values[3];
                string color = values[4];
                string condition = values[5];
                int price = int.Parse(values[6]);
                int numberOfDoors = int.Parse(values[7]);
                Car newCar = new Car(id, brand, year, model, color, condition, price, numberOfDoors);

                allCars.Add(newCar);
            }

            foreach (Car product in allCars)
            {

                Console.WriteLine($"Id:{product.Id}, Brand: {product.Brand}, Year: {product.Year}, Model: {product.Model}, Color: {product.Color}, Condition: {product.Condition}, Price: {product.Price}, numberOfDoors: {product.NumberOfDoors}");

            }
        }
    }
}
