using Core.Entities;

namespace Application.Interfaces.Persistence
{
    public interface IShopRepository
    {
        Task<Shop?> GetAsync(int shopId);
        Task<Shop?> GetAsync(string shopName);
        Task<IReadOnlyList<Shop>> GetAllAsync();
        Task CreateAsync(Shop shop);
        Task UpdateAsync(Shop shop);
        Task DeleteAsync(Shop shop);
    }
}
