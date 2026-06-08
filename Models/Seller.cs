namespace TroveApi.Models;

public class Seller
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public List<Product> products {get; set;} = new();
}


