

using System.ComponentModel.DataAnnotations;

public class AuthResponseDTO
{
    public JwtBodyDTO? JwtBodyDTO {get; set;}
    public string jwtToken {get; set;} = string.Empty;
}

public class JwtBodyDTO
{
    public string UserName {get; set;} = string.Empty;
    public string FirstName {get; set;} = string.Empty;
    public string LastName {get; set;} = string.Empty;

    [EmailAddress]
    public string Email {get; set;} = string.Empty;


}