using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TroveApi.Models;

public class User : IdentityUser<int>
{

   
    public string FirstName {get; set;} = string.Empty;
    public string LastName {get; set;} = string.Empty;

  
    public bool IsSeller {get; set;} = false;

    public int? SellerId {get; set;}
    public Seller? Seller {get; set;}
    
}