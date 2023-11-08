using Core.Entities;

namespace Application.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(int email);
    Task CreateUserAsync(User user);
}
