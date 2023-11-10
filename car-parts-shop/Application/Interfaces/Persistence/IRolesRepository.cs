using Core.Entities;

namespace Application.Interfaces.Persistence;

public interface IRolesRepository
{
    Task<Role?> GetRoleByNameAsync(string name);
}
