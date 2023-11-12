namespace Core.Entities;

public class Car
{
    public int Id { get; set; }
    public DateTime FirstRegistration { get; set; }
    public int Mileage { get; set; }
    public float Engine { get; set; }
    public int Power { get; set; }
    public BodyType Body { get; set; } = null!;
    public FuelType Fuel { get; set; } = null!;
    public GearboxType Gearbox { get; set; } = null!;
    public Model Model { get; set; } = null!;
    public Shop Shop { get; set; } = null!;
}
