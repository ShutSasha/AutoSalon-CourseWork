namespace CarDealership
{
    class Car
    {   
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public int Price { get; set; }

        public Car(int id,string brand, int year, string model, string color, string condition, int price)
        {
            Id = id;
            Brand = brand;
            Year = year;
            Model = model;
            Color = color;
            Condition = condition;
            Price = price;
        }

        public Car()
        {
        }
    }
}
