namespace Core.Entities;

public class UserRole
{
    public int Id { get; set; }
    public Role Role { get; set; } = null!;
    public User User { get; set; } = null!;
}