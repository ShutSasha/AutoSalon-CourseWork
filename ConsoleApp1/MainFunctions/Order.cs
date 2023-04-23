//using CarDealership.MainFunctions.ClientFunctions;
//using System.Text;

//namespace CarDealership.MainFunctions
//{
//    internal class Order
//    {
//        public static void CreateOrder()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            PrintClients.PrintAllClients();

//            Console.ForegroundColor = ConsoleColor.Blue;
//            Console.WriteLine("\nОбиріть клієнта з списку вище, який буде робити замовлення:\n");
//            Console.ResetColor();

//            Console.Write("\nВведіть id клієнта");
//            int idClient = Convert.ToInt32(Console.ReadLine());

//            AccessFile accessFileOfClients = AccessFile.GetAccessToFile("ClientDB.txt", "..\\..\\..\\MainFunctions\\ClientFunctions");
//            string[] linesOfClients = accessFileOfClients.Lines;


//            // Пошук індексу рядка з айді, який потрібно видалити
//            int indexToDelete = -1;
//            for (int i = 0; i < lines.Length; i++)
//            {
//                string[] values = lines[i].Split(',');
//                int id = int.Parse(values[0]);

//                if (id == idToDelete)
//                {
//                    indexToDelete = i;
//                    break;
//                }
//            }

//            if (indexToDelete == -1)
//            {
//                Console.WriteLine($"Машина з айді {idToDelete} не знайдена в файлі.");
//                return;
//            }

//        }
//    }
//}
