namespace TroveApi.Models;

public class Product
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public decimal Price {get; set;}
    public int StockQuantity {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow; 

    public bool hidden {get; set;} = false;

    public double PriceModifier {get; set;} = 0.0;

    public Seller? Seller {get; set;}
    public int SellerId {get; set;}



}