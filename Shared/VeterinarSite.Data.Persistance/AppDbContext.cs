using Microsoft.EntityFrameworkCore;
using VeterinarSite.Data.Persistance.Entities;

namespace VeterinarSite.Data.Persistance;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base((DbContextOptions)options)
    {
    }
    protected AppDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    public DbSet<Student> Students { get; set; }
}