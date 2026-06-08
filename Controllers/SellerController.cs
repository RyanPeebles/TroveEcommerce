using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroveApi.Data;
using TroveApi.Models;


namespace TroveApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SellerController : ControllerBase
{
    private readonly AppDbContext _context;

    public SellerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
     public async Task<ActionResult<IEnumerable<Seller>>> GetSellers()
    {
        return await _context.Sellers.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> postSeller(SellerDTO seller)
    {
        var newSeller = new Seller
        {
            Name = seller.SellerName
        };
        _context.Sellers.Add(newSeller);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(postSeller), new { id = newSeller.Id }, newSeller);
    }
}