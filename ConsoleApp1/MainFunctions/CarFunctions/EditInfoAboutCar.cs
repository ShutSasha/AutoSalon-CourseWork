using CarDealership.Utils;
using CarDealership.ValidatorsMethods;

namespace CarDealership.MainFunctions.CarFunctions
{
    internal class EditInfoAboutCar
    {
        public void SelectChanges(string[] lines, int id, string filePath)
        {
            Console.WriteLine("Оберіть, що ви хочете в ньому змінити\n" + "1. Бренд\n" + "2. Рік\n" + "3. Модель\n" + "4. Колір\n" + "5. Стан автомобіля\n" + "6. Ціна\n" + "7. Кількість дверей автомобіля");

            MenuText.OutputEnterNumOfFunc();

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber >= 1 && selectedNumber <= 7)
            {
                string[] fieldNames = { "бренд", "рік", "модель", "колір", "стан автомобіля", "ціна", "кількість дверей" };
                Console.Write($"Введіть нове значення для поля '{fieldNames[selectedNumber - 1]}': ");
                string newValue = "";
                switch (selectedNumber)
                {
                    case 1:
                        newValue = InputValidators.BrandInputValidator();
                        break;
                    case 2:
                        newValue =Convert.ToString(InputValidators.YearInputOfVehicle());
                        break;
                    case 3:
                        newValue = InputValidators.ModelInputValidator();
                        break;
                    case 4:
                        newValue = InputValidators.ColorInputValidator();
                        break;
                    case 5:
                        newValue = InputValidators.ConditionInputValidator();
                        break;
                    case 6:
                        newValue = Convert.ToString(InputValidators.PriceInputValidator());
                        break;
                    case 7:
                        newValue = Convert.ToString(InputValidators.NumberOfDoorsInputValidator());
                        break;
                    default:
                      
                        break;
                }
                string[] carData = lines[id - 1].Split(',');
                carData[selectedNumber] = newValue;
                lines[id - 1] = string.Join(",", carData);
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Поле '{fieldNames[selectedNumber - 1]}' змінено на '{newValue}'");
            }
            else
            {
                MenuText.SuccessOutput("Ви ввели неіснуючу функцію, спробуйте ще раз");
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
                MenuText.ErrorOutputText("\nВи ввели неіснуючий id автомобіля, спробуйте ще раз");
                EditInfoAboutCarMethod();

            }
        }
    }
}
