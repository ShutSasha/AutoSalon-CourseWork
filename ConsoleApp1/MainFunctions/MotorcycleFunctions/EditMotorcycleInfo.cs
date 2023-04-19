using CarDealership.MainFunctions.ClientFunctions;
using CarDealership.Models;
using CarDealership.ValidatorsMethods;
using System.Text;

namespace CarDealership.MainFunctions.MotorcycleFunctions
{
    public class EditMotorcycleInfo
    {
        public void SelectChanges(string[] lines, int id, string filePath)
        {

            string outputText = "Оберіть, що ви хочете в ньому змінити\n" + "1. Бренд\n" + "2. Рік\n" + "3. Модель\n" + "4. Колір\n" + "5. Технічний стан\n" + "6. Ціна\n" + "7. Тип мотоцикла\n";
            Console.WriteLine(outputText);

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber >= 1 && selectedNumber <= Validators.FindMaxNumberInString(outputText))
            {
                string[] fieldNames = { "Бренд", "Рік", "Модель", "Колір", "Технічний стан", "Максимальна ціна", "Ціна", "Тип мотоцикла" };
                Console.Write($"Введіть нове значення для поля '{fieldNames[selectedNumber - 1]}': ");
                string newValue = Console.ReadLine();
                string[] motorcycleData = lines[id - 1].Split(',');
                motorcycleData[selectedNumber] = newValue;
                lines[id - 1] = string.Join(",", motorcycleData);
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Поле '{fieldNames[selectedNumber - 1]}' змінено на '{newValue}'");


            }
            else
            {
                Console.WriteLine("Ви ввели неіснуючу функцію, спробуйте ще раз");
                SelectChanges(lines, id, filePath);
            }
        }
        public static void EditInfoAboutMotorcycleMethod()
        {

            AccessFile accessFileOfMotorcycles = AccessFile.GetAccessToFile("MotorcycleDB.txt", "..\\..\\..\\MainFunctions\\MotorcycleFunctions");
            string[] linesMotorcycles = accessFileOfMotorcycles.Lines;

            Console.OutputEncoding = Encoding.UTF8;

            List<Motorcycle> allMotorcycle = new List<Motorcycle>();
            PrintMotorcycle.PrintAllMotorcycles();

            Console.Write("\nВведіть id мотоцикла: ");
            int id = int.Parse(Console.ReadLine());

            foreach (string line in linesMotorcycles)
            {
                string[] values = line.Split(',');

                int idParse = int.Parse(values[0]);
                string brand = values[1];
                int year = int.Parse(values[2]);
                string model= values[3];
                string color = values[4];
                string condition = values[5];
                int price = int.Parse(values[6]);
                string motorcycleType = values[7];


                Motorcycle newMotorcycle = new Motorcycle(idParse, brand, year, model, color, condition, price, motorcycleType);

                allMotorcycle.Add(newMotorcycle);
            }

            bool checkId = CheckIdExists.CheckIdExistsVehicle(allMotorcycle, id);

            if (checkId)
            {
                EditMotorcycleInfo changesAboutMotorcycle = new EditMotorcycleInfo();
                changesAboutMotorcycle.SelectChanges(linesMotorcycles, id, accessFileOfMotorcycles.FilePath);
            }

            else
            {
                Console.WriteLine("\nВи ввели неіснуючий id мотоцикла, спробуйте ще раз");
                EditInfoAboutMotorcycleMethod();

            }

        }
    }
}
