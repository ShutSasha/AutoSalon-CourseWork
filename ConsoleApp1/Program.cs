using System.Text;

namespace CarDealership
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            var StartTheProgram =  new StartTheProgram();

            StartTheProgram.Start(); 
        }
    }
}