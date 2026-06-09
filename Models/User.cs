namespace TroveApi.Models;

public class User
{

    public int Id {get; set;}
    public string UserName {get; set;} = string.Empty;

    public string FirstName {get; set;} = string.Empty;
    public string LastName {get; set;} = string.Empty;

    public bool IsSeller {get; set;} = false;

    public int? SellerId {get; set;}
    public Seller? Seller {get; set;}
}