
using System.ComponentModel.DataAnnotations;

public class ProductDTO
{
    [Required]
    public string Name {get; set;} = string.Empty;
    [Required]
    public decimal Price {get; set; } 
    [Required]
    public int Stock {get; set;} = 0;

    
}