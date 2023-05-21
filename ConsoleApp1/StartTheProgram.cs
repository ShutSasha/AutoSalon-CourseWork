using CarDealership.Utils;
using CarDealership.ValidatorsMethods;


namespace CarDealership
{
    public class StartTheProgram
    {
        private AutoSalon salon;

        public StartTheProgram(AutoSalon salon)
        {
            this.salon = salon;
        }

        public StartTheProgram()
        {

        }
        public void Start()
        {
        
            bool checkLoop = true;

            do
            {
                Console.WriteLine(MenuText.chooseOneFunction);

                MenuText.BlueOutput("\nНапишіть тут номер функції, яку хочете виконати: ");

                bool isInputValid = int.TryParse(Console.ReadLine(), out int selectedNumber);
                if (!isInputValid)
                {
                    MenuText.ErrorOutputText("Ввід не коректний. Спробуйте щось ввести, якщо нічого не вводили, а також повинні вводитися лише цифри.");
                    Start();
                }
                Console.WriteLine();

                Validators.ValidatorInputValue(selectedNumber, Validators.FindMaxNumberInString(MenuText.chooseOneFunction), salon);

                Validators.CheckSelectedFunction(selectedNumber, salon, this);

            } while (checkLoop);
        }
    }
}
