namespace Core.Entities;

public class User
{
    public required Guid Id { get; set; } = Guid.NewGuid();
    public required string Email { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string PhoneNumber { get; set; }
    public required string HashedPassword { get; set; }
}
