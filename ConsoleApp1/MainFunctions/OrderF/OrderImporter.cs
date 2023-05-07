//using CarDealership.Models;
//using System.Collections.Generic;

//namespace CarDealership.MainFunctions.OrderF
//{
//    public class OrderImporter
//    {
//        public static List<string> ImportOrdersFromFile(string[] lines)
//        {
//            List<string> orders = new List<string>();

//            foreach (string line in lines)
//            {
//                string[] values = line.Split(',');
               
//                string brand = values[1];
           
//                string model = values[3];
//                string color = values[4];
//                string condition = values[5];

//                List<string> newCar =new List(brand, model, color, condition);
//                orders.Add(newCar);
//            }

//            return orders;
//        }
//    }
//}
