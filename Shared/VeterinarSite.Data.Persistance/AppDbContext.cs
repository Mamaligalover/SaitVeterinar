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
    public DbSet<LucratorMedical> LucratorMedicals { get; set; }
    public DbSet<FileName> FileNames { get; set; }
    public DbSet<BirouExecutivCMV> BirouExecutivCMVs { get; set; }
    public DbSet<ComponentaComisieiDentologiceSiLitigii> ComponentaComisieiDentologiceSiLitigii { get; set; }
    public DbSet<FileContent> FileContente { get; set; }
    public DbSet<ComponentaComisieiPentruStiintaCercetareFormare> ComponentaComisieiPentruStiintaCercetareFoRmare { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cenzor> Cenzors { get; set; }
    public DbSet<SearchAndResourchePeople> SearchAndResourchePeoples { get; set; }



}