public class Carrier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string SpeedDescription { get; set; }

    public Carrier(int id, string name, int price, string speedDescription)
    {
        Id = id;
        Name = name;
        Price = price;
        SpeedDescription = speedDescription;
    }
}