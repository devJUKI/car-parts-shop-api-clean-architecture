namespace Core.Entities;

public class Part
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public Car Car { get; set; } = null!;
}
