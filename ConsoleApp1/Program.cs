using System.Text;

namespace CarDealership
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            AutoSalon Salon = new AutoSalon();

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(ConsoleExit);

            StartTheProgram StartTheProgram = new StartTheProgram(Salon);
            Salon.LoadData();
            StartTheProgram.Start();

            void ConsoleExit(object sender, EventArgs e)
            {
                Salon.SaveData();
            }

        }
    }
}