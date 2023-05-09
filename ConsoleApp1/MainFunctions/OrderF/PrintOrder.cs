using ConsoleTables;

namespace CarDealership.MainFunctions.OrderF
{
    public class PrintOrder
    {
        public static void PrintOrdersMethod()
        {
            AccessFile accessFile = AccessFile.GetAccessToFile("SoldOut.txt", "..\\..\\..\\MainFunctions\\OrderF");
            string[] lines = accessFile.Lines;
          
            var table = new ConsoleTable("ID", "ПІБ", "Телефон", "Пошта", "Бренд траспорту", "Рік випуску", "Модель", "Price ($)", "Постачальник", "Перевізник", "Загальна ціна");

            foreach (var line in lines)
            {
                var newline = line.Split(",");
                table.AddRow(
                   newline[0],
                   newline[1],
                   newline[2],
                   newline[3],
                   newline[4],
                   newline[5],
                   newline[6],
                   newline[7],
                   newline[8],
                   newline[9],
                   newline[10]
                    );
            }
            Console.Write(table.ToString());
        }
    }  
}