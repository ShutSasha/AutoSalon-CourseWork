using CarDealership.Models;
using CarDealership.ValidatorsMethods;
using System.Text;

namespace CarDealership.MainFunctions.TruckFunctions
{
    public class EditTruckInfo
    {
        public void SelectChanges(string[] lines, int id, string filePath)
        {

            string outputText = "Вибиріть, що Ви хчоете змінити:\n" + "1. Бренд\n" + "2. Рік випуску\n" + "3. Модель\n" + "4. Колір\n" + "5. Технічний стан\n" + "6. Ціна\n" + "7. Кількість колес\n" + "8. Вантажопідйомність\n";
            Console.WriteLine(outputText);

            int selectedNumber = Convert.ToInt32(Console.ReadLine());

            if (selectedNumber >= 1 && selectedNumber <= Validators.FindMaxNumberInString(outputText))
            {
                string[] fieldNames = { "Бренд", "Рік випуску", "Модель", "Колір", "Технічний стан", "Ціна", "Кількість колес", "Вантажопідйомність" };
                Console.Write($"Введіть нове значення для поля '{fieldNames[selectedNumber - 1]}': ");
                string newValue = "";
                switch (selectedNumber)
                {
                    case 1:
                        newValue = InputValidators.BrandInputValidator();
                        break;
                    case 2:
                        newValue = Convert.ToString(InputValidators.YearInputOfVehicle());
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
                        newValue = Convert.ToString(InputValidators.NumberOfWheelsInputValidator());
                        break;
                    case 8:
                        newValue = Convert.ToString(InputValidators.LoadCapacityInputValidator());
                        break;
                    default:
                        break;
                }
                string[] truckData = lines[id - 1].Split(',');
                truckData[selectedNumber] = newValue;
                lines[id - 1] = string.Join(",", truckData);
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Поле '{fieldNames[selectedNumber - 1]}' змінено на '{newValue}'");


            }
            else
            {
                Console.WriteLine("Ви ввели неіснуючу функцію, спробуйте ще раз");
                SelectChanges(lines, id, filePath);
            }
        }
        public static void EditInfoAboutTruckMethod()
        {

            AccessFile accessFileOfTrucks = AccessFile.GetAccessToFile("TruckDB.txt", "..\\..\\..\\MainFunctions\\TruckFunctions");
            string[] linesTrucks = accessFileOfTrucks.Lines;

            Console.OutputEncoding = Encoding.UTF8;

            List<Truck> allTrucks = new List<Truck>();
            PrintTruck.PrintAllTrucks();

            Console.Write("\nВведіть id грузовика: ");
            int id = int.Parse(Console.ReadLine());

            foreach (string line in linesTrucks)
            {
                string[] values = line.Split(',');

                int idParse = int.Parse(values[0]);
                string brand = values[1];
                int year = int.Parse(values[2]);
                string model = values[3];
                string color = values[4];
                string condition = values[5];
                int price = int.Parse(values[6]);
                int numberOfWheels = int.Parse(values[7]);
                int loadCapacity = int.Parse(values[8]);


                Truck newTruck = new Truck(idParse, brand, year, model, color, condition, price, numberOfWheels, loadCapacity);

                allTrucks.Add(newTruck);
            }
            bool checkId = CheckIdExists.CheckIdExistsVehicle(allTrucks, id);

            if (checkId)
            {
                EditTruckInfo changesAboutTruck = new EditTruckInfo();
                changesAboutTruck.SelectChanges(linesTrucks, id, accessFileOfTrucks.FilePath);
            }
            else
            {
                Console.WriteLine("\nВи ввели неіснуючий id вантажівки, спробуйте ще раз");
                EditInfoAboutTruckMethod();
            }


        }
    }
}