using Microsoft.EntityFrameworkCore;
using TroveApi.Models;

namespace TroveApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products {get; set;}
}
