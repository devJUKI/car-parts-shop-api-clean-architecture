using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Persistence;

namespace Infrastructure.Persistence.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly CarPartsShopDbContext _context;

        public UserRepository(CarPartsShopDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            return _context.Users
                .Where(u => u.Email == email)
                .SingleOrDefaultAsync();
        }

        public async Task<Role?> GetRoleByNameAsync(string name)
        {
            return await _context.Roles
                .Where(r => r.Name == name)
                .SingleOrDefaultAsync();
        }

        public async Task AddRoleToUserAsync(User user, string roleName)
        {
            var role = await _context.Roles
                .Where(r => r.Name == roleName)
                .SingleOrDefaultAsync();

            if (role == null)
            {
                return;
            }

            var userRole = new UserRole { Role = role, User = user };

            _context.UserRoles
                .Add(userRole);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetUserRolesAsync(Guid userId)
        {
            return await _context.UserRoles
                .Where(u => u.User.Id == userId)
                .Select(u => u.Role)
                .ToListAsync();
        }
    }
}
