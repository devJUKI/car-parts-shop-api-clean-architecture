using Core.Entities;

namespace Application.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task CreateUserAsync(User user);
}
