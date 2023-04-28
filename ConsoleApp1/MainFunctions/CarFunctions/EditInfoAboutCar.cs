using System.Text;
using CarDealership.ValidatorsMethods;

namespace CarDealership.MainFunctions.CarFunctions
{
    internal class EditInfoAboutCar
    {

        public void SelectChanges(string[] lines, int id, string filePath)
        {
            Console.OutputEncoding = Encoding.UTF8;

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

            var allCars = CarImporter.ImportCarsFromFile(lines);
            PrintCars.PrintCarsMethod();

            Console.Write("\nВведіть id автомобіля: ");
            int id = int.Parse(Console.ReadLine());

            bool checkId = CheckIdExists.CheckIdExistsVehicle(allCars, id);

            if (checkId)
            {
                EditInfoAboutCar changesAboutCar = new EditInfoAboutCar();
                changesAboutCar.SelectChanges(lines, id, accessFile.FilePath);
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВи ввели неіснуючий id автомобіля, спробуйте ще раз");
                Console.ResetColor();
                EditInfoAboutCarMethod();

            }

        }

    }

}
