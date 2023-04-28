using CarDealership.Models;

public class CarImporter
{
    public static List<Car> ImportCarsFromFile(string[] lines)
    {
        List<Car> allCars = new List<Car>();

        foreach (string line in lines)
        {
            string[] values = line.Split(',');
            int idParse = int.Parse(values[0]);
            string brand = values[1];
            int year = int.Parse(values[2]);
            string model = values[3];
            string color = values[4];
            string condition = values[5];
            int price = int.Parse(values[6]);
            int numberOfDoors = int.Parse(values[7]);
            Car newCar = new Car(idParse, brand, year, model, color, condition, price, numberOfDoors);
            allCars.Add(newCar);
        }

        return allCars;
    }
}