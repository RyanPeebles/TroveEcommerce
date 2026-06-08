
using System.ComponentModel.DataAnnotations;

public class SellerDTO
{
    [Required]
    public string SellerName {get; set;} = String.Empty;
}