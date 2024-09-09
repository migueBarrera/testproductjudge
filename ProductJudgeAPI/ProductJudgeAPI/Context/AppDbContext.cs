using Microsoft.EntityFrameworkCore;
using ProductJudgeAPI.Entities;

namespace ProductJudgeAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Judge> Judges { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Barcode> Barcodes { get; set; }


}
