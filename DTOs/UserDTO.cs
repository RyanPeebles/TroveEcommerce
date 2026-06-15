

using System.ComponentModel.DataAnnotations;

public class UserDTO
{
   
    public string UserName {get; set;} = string.Empty;
    
    public string FirstName {get; set;} = string.Empty;
    public string LastName {get; set;} = string.Empty;

    [EmailAddress]
    public string Email {get; set;} = string.Empty;
    public string password {get; set;} = string.Empty;
}

public class LoginDTO
{
    public string UserName {get; set;} = string.Empty;

    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email {get; set;} = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string password {get; set;} = string.Empty;
}