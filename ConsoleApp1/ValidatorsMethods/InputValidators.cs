using CarDealership.Utils;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CarDealership.ValidatorsMethods
{
    public class InputValidators
    {
        public static string BrandInputValidator()
        {
            while (true)
            {
                Console.Write("Введіть бренд транспорту (до 20 символів): ");
                string brand = Console.ReadLine()?.Trim();
                string tempBrand = brand.Replace(" ", "");
                if (!string.IsNullOrEmpty(brand) && brand.Length <= 20 && tempBrand.All(c => Char.IsLetter(c)))
                {
                    brand = Regex.Replace(brand, @"\s+", " ");

                    if (brand == brand.ToUpper())
                    {
                        return brand;
                    }

                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                    brand = textInfo.ToTitleCase(brand.ToLower());

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
                        return year;
                    }
                }
                MenuText.ErrorOutputText("Неправильний рік випуску. Будь ласка, спробуйте ще раз. Потрібно вводити рік тільке від 1920-нині");
            }
        }

        public static int YearInputFromTo(string prompt, int minYear, int maxYear)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int year) && year >= minYear && year <= maxYear)
                {
                    return year;
                }
                MenuText.ErrorOutputText($"Неправильний рік випуску. Будь ласка, спробуйте ще раз. Потрібно вводити рік тільки від {minYear} до {maxYear}");
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
                string tempColor = color.Replace(" ", "");
                if (!string.IsNullOrEmpty(color) && color.Length <= 20 && tempColor.All(c => char.IsLetter(c)))
                {
                    color = Regex.Replace(color, @"\s+", " ");
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
                    && validConditions.Contains(condition, StringComparer.OrdinalIgnoreCase))
                {
                    condition = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(condition.ToLower());
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
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. Ціна повинна бути від  1.000$ до 3.000.000$");
            }
        }


        public static int PriceInputFromTo(string prompt, int minValue, int maxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int price) && price >= minValue && price <= maxValue)
                {
                    return price;
                }
                MenuText.ErrorOutputText($"Неправильний ввід. Будь ласка, спробуйте ще раз. Ціна повинна бути від {minValue}$ до {maxValue}$");
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
                    motorcycleType = char.ToUpper(motorcycleType[0]) + motorcycleType.Substring(1);
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
                //Console.OutputEncoding = Encoding.Unicode;
                //Console.InputEncoding = Encoding.Unicode;
                Console.Write("Введіть ПІБ клієнта: ");
                string fullName = Console.ReadLine()?.Trim();
                string tempFullName = fullName.Replace(" ", "");

                if (!string.IsNullOrEmpty(fullName) && fullName.Length <= 60 && tempFullName.All(c => char.IsLetter(c)))
                {
                    fullName = Regex.Replace(fullName, @"\s+", " ");

                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                    fullName = textInfo.ToTitleCase(fullName.ToLower());

                    return fullName;
                }
                MenuText.ErrorOutputText("Неправильний ввід. Будь ласка, спробуйте ще раз. До 60 символів та тільки букви");
            }
        }

        public static string EmailInputValidator()
        {
            string email;
            while (true)
            {
                Console.Write("Введіть електронну пошту: ");
                email = Console.ReadLine();

                if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return email;
                }
                MenuText.ErrorOutputText("Неправильний формат електронної пошти. Будь ласка, спробуйте ще раз.");
            }
        }
        public static string GetValidPhoneNumber()
        {
            string phoneNumber;
            while (true)
            {
                Console.Write("Введіть номер телефону строго за форматом (+380 ХХ ХХХХХХХ): ");
                phoneNumber = Console.ReadLine();

                phoneNumber = phoneNumber.Replace(" ", string.Empty);

                if (phoneNumber.Length != 13)
                {
                    MenuText.ErrorOutputText("Неправильний номер телефону. Номер повинен мати 12 цифр.");
                    continue;
                }

                if (!phoneNumber.StartsWith("+380"))
                {
                    MenuText.ErrorOutputText("Неправильний номер телефону. Номер повинен починатися з +380.");
                    continue;
                }

                if (!phoneNumber.Substring(1).All(char.IsDigit))
                {
                    MenuText.ErrorOutputText("Неправильний номер телефону. Номер повинен містити тільки цифри.");
                    continue;
                }

                return phoneNumber;
            }
        }
    }
}
