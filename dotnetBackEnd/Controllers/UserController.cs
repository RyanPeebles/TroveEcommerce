using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using TroveApi.Data;
using TroveApi.Models;
using TroveApi.Services;


namespace TroveApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IEmailSender _emailService;
    public UserController(UserManager<User> userManager, AppDbContext context, ITokenService tokenService, IEmailSender emailService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
        _emailService = emailService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _userManager.Users.ToListAsync();
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> CreateUser([FromBody] UserDTO user)
    {
        
        var newUser = new User
        {
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName, 
            Email = user.Email
        };
        
        var result = await _userManager.CreateAsync(newUser, user.password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

        var confirmationLink = $"https://localhost:5000/api/User/auth/confirm-email?userId={newUser.Id}&token={Uri.EscapeDataString(emailToken)}";

        await _emailService.SendEmailAsync(newUser.Email,"Confrim your email.",$"Please click the link to confirm your Email: {confirmationLink}");

        return Ok($"Account registered. Please validate Email by clicking the link sent to {user.Email} to continue.");
    } 


    [HttpGet("auth/confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
        {
            return BadRequest("Invalid email confirmation parameters.");
        } 
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null){ return NotFound("User not found");}
        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (result.Succeeded)
        {
           
            return Ok(new { 
                message = "Email successfully verified! You can now log in using Postman." 
            });
        }

        return BadRequest("Email confirmation failed.");
          
    }

    [HttpPost("{userId}/Seller")]
    public async Task<ActionResult<Seller>> CreateSellerFromUser([FromRoute] string userId,[FromBody] SellerDTO seller)
    {

   
        var userContext = await _userManager.FindByIdAsync(userId);
        if (userContext == null)
        {
            return BadRequest("User not found");

        }
        if (userContext.IsSeller)
        {
            return BadRequest("User is already a seller");
        }
        var newSeller = new Seller
        {
            Name = seller.SellerName
        };
        userContext.IsSeller = true;
        
        userContext.Seller = newSeller;
        _context.Sellers.Add(newSeller);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateSellerFromUser), new {id= newSeller.Id}, newSeller);
    }

    [HttpGet("login")]
    public async Task<IActionResult> LogInUser(LoginDTO u)
    {
        User? user = await _userManager.FindByEmailAsync(u.Email);
        if (user == null)
        {
            user = await _userManager.FindByNameAsync(u.UserName);
        }
       if(user == null)
        {
            return Unauthorized($"Invalid Username or Email. UName: {u.UserName}, Email: {u.Email}");
        }
        
        
        if (!await _userManager.CheckPasswordAsync(user, u.password))
        {
            return Unauthorized("Invalid password");
        }
        string jwtToken = _tokenService.CreateToken(user);
        return Ok(new AuthResponseDTO
        {
            jwtToken = jwtToken,
            JwtBodyDTO = new JwtBodyDTO
            {
                UserName = user.UserName!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            }
        });
            
        
    }
}