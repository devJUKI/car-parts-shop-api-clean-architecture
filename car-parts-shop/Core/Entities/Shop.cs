namespace Core.Entities;

public class Shop
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public User? User { get; set; }
}
