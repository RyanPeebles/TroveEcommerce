using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroveApi.Data;
using TroveApi.Models;


namespace TroveApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
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
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(CreateUser), new { id = newUser.Id }, newUser);
    } 

    [HttpPost("{userId}/Seller")]
    public async Task<ActionResult<Seller>> CreateSellerFromUser([FromRoute] int userId,[FromBody] SellerDTO seller)
    {

   
        var userContext = await _context.Users.FindAsync(userId);
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