namespace CarDealership.Utils
{
    public class MenuText
    {
        public static string chooseOneFunction = "\nВиберіть, одну з функцій нижче:\n\n" + "1. Додати автомобіль, клієнта, мотоцикл тощо до автосалону.\n" + "2. Редагування інформацію щодо автомобілів, клієнтів, мотоциклів тощо.\n" + "3. Автоматизація підбору варіантів для покупця.\n" +
                "4. Показати базу автомобілів, клієнтів тощо\n" +
            "5. Пошук транспорту за маркою, рік тощо.\n" +
            "6. Видалити транспорт, клієнта тощо з списку.\n" +
            "7. Зробити замовлення.\n" +
            "-1. Вихід";

        public static string exitOrContinueForChanges = "\n\nВибиріть одну з функцій нижче:\n" +
            "\n1. Вийти до головного меню" +
            "\n2. Вихід з програми";

        public static string ChoosePrintForVehicle = "Виберіть, що хочете надрукувати, щоб потім обрати транспорт для покупки:\n" +
                    "1. Автомобілі.\n" +
                    "2. Мотоцикли.\n" +
                    "3. Грузовики.";

        public static string ChooseProvider = "Обиріть постачальника нижче:\n" +
                                "1. Амереканський - найдорожчий та найбільш якісний транспорт (+1000$ до вартості транспорту)\n" +
                                "2. Європейський - якісний транспорт та найдійний постачальник (+700$ до вартості транспорту)\n" +
                                "3. Постачальник з Японії - якісний транспорт (+500$ до вартості транспорту)";
        public static string ChooseCarrier = "Обиріть перевізника нижче:\n" +
                                "1. Швидкий (+1000$ до загальної вартості)\n" +
                                "2. Із середньою швидкістю (+700$ до загальної вартості)\n" +
                                "3. Повільний (+500$ до загальної вартості)";
        public static void ErrorOutputText(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }

        public static void SuccessOutput(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        public static void OutputErrorOfNoMatchingVehicle(string vehicle)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nNo matching {vehicle} found.");
            Console.ResetColor();
        }
        public static void OutputEnterNumOfFunc()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nВведіть тут цифру функції: ");
            Console.ResetColor();
        }
        
        public static void BlueOutput(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(text);
            Console.ResetColor();
        }

        public static string[] carHeader = new string[]
      {
            "ID",
            "Brand",
            "Year",
            "Model",
            "Color",
            "Condition",
            "Price",
            "numberOfDoors"
      };

        public static string[] bikeHeader = new string[]
        {
            "ID",
            "Бренд",
            "Рік випуску",
            "Модель",
            "Колір",
            "Стан",
            "Ціна",
            "Тип мотоцикла"
        };

        public static string[] truckHeader = new string[]
       {
            "ID",
            "Бренд",
            "Рік випуску",
            "Модель",
            "Колір",
            "Стан",
            "Ціна",
            "Кількість коліс",
            "Грузопідйомність(У тоннах)"
       };
    }
}
