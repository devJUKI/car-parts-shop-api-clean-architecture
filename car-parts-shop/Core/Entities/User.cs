namespace Core.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string HashedPassword { get; set; } = null!;
}
