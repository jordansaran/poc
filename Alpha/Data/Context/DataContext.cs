using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class DataContext : DbContext
{
    public string _test;
    
    public DataContext (DbContextOptions<DataContext> options)
        : base(options)
    {
        _test = "teste";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("DataContext");
        }
    }
    
    public DbSet<User> User { get; set; } = default!;
    public DbSet<Product> Product { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Product>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Product>()
            .Property(c => c.Unit)
            .HasConversion<int>();
    }
}

