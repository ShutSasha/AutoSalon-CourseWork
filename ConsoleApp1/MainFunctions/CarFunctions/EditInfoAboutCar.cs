using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using CarDealership.Models;
using CarDealership.ValidatorsMethods;
using static CarDealership.MainFunctions.ExitOrContinue;

namespace CarDealership.MainFunctions.CarFunctions
{
    internal class EditInfoAboutCar
    {
        public void SelectChanges(string[] lines, int id, string filePath)
        {
            Console.WriteLine("Оберіть, що ви хочете в ньому змінити\n" + "1. Бренд\n" + "2. Рік\n" + "3. Модель\n" + "4. Колір\n" + "5. Стан автомобіля\n" + "6. Ціна\n" + "7. Кількість дверей автомобіля");

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber >= 1 && selectedNumber <= 7)
            {
                string[] fieldNames = { "бренд", "рік", "модель", "колір", "стан автомобіля", "ціна", "кількість дверей" };
                Console.Write($"Введіть нове значення для поля '{fieldNames[selectedNumber - 1]}': ");
                string newValue = Console.ReadLine();
                string[] carData = lines[id - 1].Split(',');
                carData[selectedNumber] = newValue;
                lines[id - 1] = string.Join(",", carData);
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Поле '{fieldNames[selectedNumber - 1]}' змінено на '{newValue}'");


            }
            else
            {
                Console.WriteLine("Ви ввели неіснуючу функцію, спробуйте ще раз");
                SelectChanges(lines, id, filePath);
            }
        }
        public static void EditInfoAboutCarMethod()
        {

            AccessFile accessFile = AccessFile.GetAccessToFile("CarDB.txt", "..\\..\\..\\MainFunctions\\CarFunctions");
            string[] lines = accessFile.Lines;


            Console.OutputEncoding = Encoding.UTF8;

            List<Car> allCars = new List<Car>();
            PrintAllCars.PrintAllCarsMethod();

            Console.Write("\nВведіть id автомобіля: ");
            int id = int.Parse(Console.ReadLine());

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                int idParse = int.Parse(values[0]);
                string brand = values[1];
                int year = int.Parse(values[2]);
                string model = values[3];
                string color = values[4];
                string condition = values[5];
                int price = int.Parse(values[6]);
                int numberOfDoors = int.Parse(values[7]);
                Car newCar = new Car(idParse, brand, year, model, color, condition, price, numberOfDoors);

                allCars.Add(newCar);
            }

            bool checkId = CheckIdExists.CheckIdExistsVehicle(allCars, id);

            if (checkId)
            {
                EditInfoAboutCar changesAboutCar = new EditInfoAboutCar();
                changesAboutCar.SelectChanges(lines, id, accessFile.FilePath);
            }

            else
            {

                Console.WriteLine("\nВи ввели неіснуючий id автомобіля, спробуйте ще раз");
                EditInfoAboutCarMethod();

            }

        }

    }

}
