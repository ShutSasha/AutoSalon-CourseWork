using System.Text;

namespace CarDealership
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            var Salon = new AutoSalon();

            var StartTheProgram = new StartTheProgram(Salon);
            Salon.LoadData();
            StartTheProgram.Start();

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(ConsoleExit);

            void ConsoleExit(object sender, EventArgs e)
            {
                AutoSalon.SaveData(Salon);
            }

        }
    }
}