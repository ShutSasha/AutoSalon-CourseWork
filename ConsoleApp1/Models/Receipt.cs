public class Receipt
{
    public string ClientName { get; set; }
    public string ClientEmail { get; set; }
    public string ClientPhone { get; set; }
    public int VehiclePrice { get; set; }
    public string VehicleBrand { get; set; }
    public string VehicleModel { get; set; }
    public string VehicleColor { get; set; }
    public string SupplierName { get; set; }
    public int SupplierPrice { get; set; }
    public string CarrierName { get; set; }
    public int CarrierPrice { get; set; }
    public int TotalPrice { get; set; }
    public DateTime PurchaseDate { get; set; }
    public Receipt(string clientName, string clientEmail, string clientPhone, int vehiclePrice, string vehicleBrand, string vehicleModel, string vehicleColor, string supplierName, int supplierPrice, string carrierName, int carrierPrice, int totalPrice, DateTime purchaseDate)
    {
        ClientName = clientName;
        ClientEmail = clientEmail;
        ClientPhone = clientPhone;
        VehiclePrice = vehiclePrice;
        VehicleBrand = vehicleBrand;
        VehicleModel = vehicleModel;
        VehicleColor = vehicleColor;
        SupplierName = supplierName;
        SupplierPrice = supplierPrice;
        CarrierName = carrierName;
        CarrierPrice = carrierPrice;
        TotalPrice = totalPrice;
        PurchaseDate = purchaseDate;
    }

}