//using CarDealership.Validators;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using CarDealership.MainFunctions;
using CarDealership.ValidatorsMethods;

namespace CarDealership.MainFunctions
{
    internal class EditInfoAboutCar
    {
        public void SelectChanges(string[] lines, int id, string filePath)
        {
            Console.WriteLine("Оберіть, що ви хочете в ньому змінити\n" + "1. Бренд\n" + "2. Рік\n" + "3. Модель\n" + "4. Колір\n" + "5. Стан автомобіля\n" + "6. Ціна\n");

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber >= 1 && selectedNumber <= 6)
            {
                string[] fieldNames = { "бренд", "рік", "модель", "колір", "стан автомобіля", "ціна" };
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

            string fileName = "File.txt";
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\MainFunctions"));
            string filePath = Path.Combine(projectPath, fileName);

            string[] lines = File.ReadAllLines(filePath);

            Console.OutputEncoding = Encoding.UTF8;

            List<Car> allCars = new List<Car>();
            PrintAllCars.PrintAllCarsMethod(allCars);

            Console.Write("\nВведіть id автомобіля: ");
            int id = int.Parse(Console.ReadLine());


            bool checkId = CheckCarIdExists.CheckCarIdExistsMethod(allCars, id);

            if (checkId)
            {
                EditInfoAboutCar changesAboutCar = new EditInfoAboutCar();
                changesAboutCar.SelectChanges(lines, id, filePath);
                ExitOrComtinue.ExitOrContinueEditCar(MenuText.exitOrContinueOutputText + "\n3. Зробити ще зміни");

            }

            else
            {

                Console.WriteLine("\nВи ввели неіснуючий id автомобіля, спробуйте ще раз");
                EditInfoAboutCarMethod();

            }

        }

    }

}
