namespace CarDealership
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PreferredBrand { get; set; }
        public int MinPrice { get; set; } 
        public int MaxPrice { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }

        


        public Client(int id, string name, string phone, string email, string preferredBrand, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email= email;
            PreferredBrand = preferredBrand;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            MinYear = minYear;
            MaxYear = maxYear;

        }
        public Client() {
        
        }
    }

}
