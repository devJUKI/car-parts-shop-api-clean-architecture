﻿using Core.Entities;

namespace Application.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task CreateUserAsync(User user);

    Task AddRoleToUserAsync(User user, string role);
    Task<List<Role>> GetUserRolesAsync(Guid userId);
}
