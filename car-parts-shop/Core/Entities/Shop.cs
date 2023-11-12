using Core.Interfaces;

namespace Core.Entities;

public class Shop : IUserOwnedResource
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public User User { get; set; } = null!;
    public Guid UserId { get; set; }
}
