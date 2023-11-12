using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DatabaseInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DatabaseInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        modelBuilder.Entity<FuelType>().HasData(
            new FuelType() { Id = 1, Name = "Diesel" }
        );

        modelBuilder.Entity<BodyType>().HasData(
            new BodyType() { Id = 1, Name = "Sedan" }
        );

        modelBuilder.Entity<Make>().HasData(
            new Make() { Id = 1, Name = "BMW" }
        );

        modelBuilder.Entity<Model>().HasData(
            new Model() { Id = 1, Name = "530d", MakeId = 1 }
        );

        modelBuilder.Entity<GearboxType>().HasData(
            new GearboxType() { Id = 1, Name = "Manual" }
        );

        modelBuilder.Entity<Role>().HasData(
            new Role() { Id = 1, Name = "User" },
            new Role() { Id = 2, Name = "Administrator" }
        );
    }
}
