using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class CarPartsShopDbContext : DbContext
{
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Part>? Parts { get; set; }
    public DbSet<Shop>? Shops { get; set; }
    public DbSet<Car>? Cars { get; set; }
    public DbSet<Make>? Makes { get; set; }
    public DbSet<Model>? Models { get; set; }
    public DbSet<BodyType>? BodyTypes { get; set; }
    public DbSet<FuelType>? FuelTypes { get; set; }
    public DbSet<GearboxType>? GearboxTypes { get; set; }

    public CarPartsShopDbContext(DbContextOptions<CarPartsShopDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Car>()
            .HasOne(b => b.Shop)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Part>()
            .HasOne(b => b.Car)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        //new DatabaseInitializer(modelBuilder).Seed();
    }
}
