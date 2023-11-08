namespace Core.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Email { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? PhoneNumber { get; set; }
    public string? HashedPassword { get; set; }
}
