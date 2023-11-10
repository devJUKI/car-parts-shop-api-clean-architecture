using Core.Entities;

namespace Application.Interfaces.Persistence
{
    public interface IPartRepository
    {
        Task<Part?> GetAsync(int shopId, int carId, int partId);
        Task<IReadOnlyList<Part>> GetAllAsync(int shopId, int carId);
        Task CreateAsync(Part part);
        Task UpdateAsync(Part part);
        Task DeleteAsync(Part part);
    }
}
