using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroveApi.Data;
using TroveApi.Models;


namespace TroveApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly AppDbContext _context;

    public UserController(UserManager<User> userManager, AppDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _userManager.Users.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] UserDTO user)
    {
        
        var newUser = new User
        {
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName 
        };
        
        var result = await _userManager.CreateAsync(newUser, user.password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return CreatedAtAction(nameof(CreateUser), new { id = newUser.Id }, newUser);
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
}