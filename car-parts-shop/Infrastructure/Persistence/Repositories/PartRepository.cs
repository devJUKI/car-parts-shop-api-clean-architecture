﻿using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Persistence;
using Core.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class PartRepository : IPartRepository
    {
        private readonly CarPartsShopDbContext context;

        public PartRepository(CarPartsShopDbContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<Part>> GetAllAsync(int shopId, int carId)
        {
            return await context
                .Parts!
                .Include(p => p.Car)
                .Include(p => p.Car!.Body)
                .Include(p => p.Car!.Fuel)
                .Include(p => p.Car!.Gearbox)
                .Include(p => p.Car!.Model)
                .Include(p => p.Car!.Shop)
                .Include(p => p.Car!.Shop!.User)
                .Where(p => p.Car!.Shop!.Id == shopId && p.Car.Id == carId).ToListAsync();
        }

        public async Task<Part?> GetAsync(int shopId, int carId, int partId)
        {
            return await context
                .Parts!
                .Include(p => p.Car)
                .Include(p => p.Car!.Body)
                .Include(p => p.Car!.Fuel)
                .Include(p => p.Car!.Gearbox)
                .Include(p => p.Car!.Model)
                .Include(p => p.Car!.Shop)
                .Include(p => p.Car!.Shop!.User)
                .FirstOrDefaultAsync(p => p.Car!.Shop!.Id == shopId && p.Car!.Id == carId && p.Id == partId);
        }

        public async Task CreateAsync(Part part)
        {
            context.Parts!.Add(part);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Part part)
        {
            context.Parts!.Update(part);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Part part)
        {
            context.Parts!.Remove(part);
            await context.SaveChangesAsync();
        }
    }
}
