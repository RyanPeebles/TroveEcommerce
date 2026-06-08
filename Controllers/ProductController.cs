using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroveApi.Data;
using TroveApi.Models;


namespace TroveApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if ( id != product.Id){return BadRequest("ID mismatch");}
        
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();

    }

    [HttpPut("Bulk_update")]
    public async Task<IActionResult> BulkUpdate([FromBody] List<Product> updatedProducts)
    {
        if(updatedProducts == null || !updatedProducts.Any()){return BadRequest("No products provided for update");}

        foreach (var product in updatedProducts)
        {
            _context.Entry(product).State = EntityState.Modified;

        }
        await _context.SaveChangesAsync();
        return Ok(new { message = $"{updatedProducts.Count} products updated successfully." });
    }

    [HttpDelete("bulkDelete/{id}")]
    public async Task<IActionResult> DeleteProductQuick(int id)
    {
        int rowsAffected = await _context.Products
        .Where(p => p.Id == id)
        .ExecuteDeleteAsync();

    if (rowsAffected == 0)
    {
        return NotFound($"Product with ID {id} was not found.");
    }

    return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductSafe(int id)
    {
        var targetProduct = await _context.Products.FindAsync(id);

        if (targetProduct == null)
        {
            return NotFound($"Product with ID {id} does not exist.");
        }

        _context.Products.Remove(targetProduct);
        await _context.SaveChangesAsync();

        return NoContent();
    } 
}