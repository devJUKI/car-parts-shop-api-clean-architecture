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
    }
}
