using System.Text;

namespace CarDealership.MainFunctions
{
    internal class PrintAllCars
    {
        static public void PrintAllCarsMethod()
        {
            List<Car> allCars = new List<Car>();
            Console.OutputEncoding = Encoding.UTF8;

            string fileName = "File.txt";
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\MainFunctions"));
            string filePath = Path.Combine(projectPath, fileName);
     
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                int id = int.Parse(values[0]);
                string brand = values[1];
                int year = int.Parse(values[2]);
                string model = values[3];
                string color = values[4];
                string condition = values[5];
                int price = int.Parse(values[6]);
                int numberOfDoors = int.Parse(values[7]);
                Car newCar = new Car(id,brand, year, model, color, condition, price, numberOfDoors);
                
                allCars.Add(newCar);
            }

            foreach (Car product in allCars)
            {

                Console.WriteLine($"Id:{product.Id}, Brand: {product.Brand}, Year: {product.Year}, Model: {product.Model}, Color: {product.Color}, Condition: {product.Condition}, Price: {product.Price}, numberOfDoors: {product.NumberOfDoors}");
  
            }
        }
    }
}
