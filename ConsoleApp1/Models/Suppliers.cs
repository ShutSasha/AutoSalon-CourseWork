public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public Supplier(int id, string name, int price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}