using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Persistence;

namespace Infrastructure.Persistence.Repositories;

public class RolesRepository : IRolesRepository
{
    private readonly CarPartsShopDbContext _context;

    public RolesRepository(CarPartsShopDbContext context)
    {
        _context = context;
    }

    public async Task<Role?> GetRoleByNameAsync(string name)
    {
        return await _context.Roles
            .Where(r => r.Name == name)
            .SingleOrDefaultAsync();
    }
}
