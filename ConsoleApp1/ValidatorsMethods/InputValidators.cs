using CarDealership.Utils;

namespace CarDealership.ValidatorsMethods
{
    public class InputValidators
    {
        public static string BrandInputValidator()
        {
            while (true)
            {
                Console.Write("Введіть бренд транспорту(до 20 символів): ");
                string brand = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(brand) && brand.Length <= 20 && brand.All(c => Char.IsLetter(c)))
                {
                    brand = char.ToUpper(brand[0]) + brand.Substring(1); // першу букву перетворюємо на велику
                    return brand;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Тільки букви та до 20 символів.");
            }
        }

        public static int YearInputOfVehicle()
        {
            int year;
            while (true)
            {
                Console.Write("Введіть рік випуску(1920-нині): ");
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    if (year >= 1920 && year <= DateTime.Now.Year)
                    {
                        return year; // якщо рік в межах 1920 - поточний рік, то повертаємо його
                    }
                }
                MenuText.ErrorOutputText("Неправильний рік випуску. Будь ласка, спробуйте ще раз. Потрібно вводити рік тільке від 1920-нині");
            }
        }

        public static string ModelInputValidator()
        {
            while (true)
            {
                Console.Write("Введіть модель транспорту(A3): ");
                string model = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(model) && model.Length <= 20)
                {
                    return model;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Тільки до 20 символів");
            }
        }
        public static string ColorInputValidator()
        {
            while (true)
            {
                Console.Write("Введіть колір транспорту (до 20 символів): ");
                string color = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(color) && color.Length <= 20 && color.All(c => char.IsLetter(c)))
                {
                    return char.ToUpper(color[0]) + color.Substring(1);
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. До 20 символів та тільки букви");
            }
        }
        public static string ConditionInputValidator()
        {
            string[] validConditions = { "Excellent", "Good", "Normal", "Bad" };

            while (true)
            {
                Console.Write("Введіть стан транспорту (Excellent, Good, Normal, Bad): ");
                string condition = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(condition)
                    && condition.Length <= 20
                    && Char.IsUpper(condition[0])
                    && validConditions.Contains(condition))
                {
                    return condition;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Можна вводити тільке ті стани, які є, а саме: Excellent, Good, Normal, Bad");
            }
        }

        public static int PriceInputValidator()
        {
            while (true)
            {
                Console.Write("Введіть ціну транспорту від 1.000$ до 3.000.000$): ");
                if (int.TryParse(Console.ReadLine(), out int price) && price >= 1000 && price <= 3000000)
                {
                    return price;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Ціна повинна бути від від 1.000$ до 3.000.000$");
            }
        }

        public static void EnterTheCharacteristicsOfTheVehicle(out string brand, out int year, out string model, out string color, out string condition, out int price)
        {
            brand = BrandInputValidator();
            year = YearInputOfVehicle();
            model = ModelInputValidator();
            color = ColorInputValidator();
            condition = ConditionInputValidator();
            price = PriceInputValidator();
        }
        public static int NumberOfDoorsInputValidator()
        {
            while (true)
            {
                Console.Write("Введіть кількість дверей автомобіля(2 або 4): ");
                string input = Console.ReadLine()?.Trim();
                if (int.TryParse(input, out int numberOfDoors) && (numberOfDoors == 2 || numberOfDoors == 4))
                {
                    return numberOfDoors;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. У автомобіля може бути тільки 2 або 4 двері");
            }
        }
        public static string BikeType()
        {
            while (true)
            {
                Console.Write("Введіть тип мотоцикла(до 20 символів): ");
                string motorcycleType = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(motorcycleType) && motorcycleType.Length <= 20 && motorcycleType.All(c => Char.IsLetter(c)))
                {
                    motorcycleType = char.ToUpper(motorcycleType[0]) + motorcycleType.Substring(1); // першу букву перетворюємо на велику
                    return motorcycleType;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Тільки букви та до 20 символів.");
            }
        }
        public static int NumberOfWheelsInputValidator()
        {
            while (true)
            {
                Console.Write("Введіть кількість коліс від 4 до 18: ");
                if (int.TryParse(Console.ReadLine(), out int numberOfWheels) && numberOfWheels >= 4 && numberOfWheels <= 18)
                {
                    return numberOfWheels;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Кількість коліс повинна бути від 4 до 18.");
            }
        }
        public static int LoadCapacityInputValidator()
        {
            while (true)
            {
                Console.Write("Введіть вантажопідйомність транспорту в тоннах (від 1 до 50): ");
                if (int.TryParse(Console.ReadLine(), out int loadCapacity) && loadCapacity >= 1 && loadCapacity <= 50)
                {
                    return loadCapacity;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Вантажопідйомність повинна бути від 1 до 50 тонн");
            }
        }

        public static string FullNameInputValidator()
        {
            while (true)
            {
                Console.Write("Введіть ПІБ клієнта: ");
                string fullName = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(fullName) && fullName.Length <= 40 && fullName.All(c => char.IsLetter(c)))
                {
                    return fullName;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. До 40 символів та тільки букви");
            }
        }
    }
}
