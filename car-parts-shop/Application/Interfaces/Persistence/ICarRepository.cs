using Core.Entities;

namespace Application.Interfaces.Persistence
{
    public interface ICarRepository
    {
        Task<Car?> GetAsync(int shopId, int carId);
        Task<IReadOnlyList<Car>> GetAllAsync(int shopId);
        Task CreateAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(Car car);
        Task<Make?> GetMakeAsync(int makeId);
        Task<Model?> GetModelAsync(int modelId);
        Task<BodyType?> GetBodyAsync(int bodyId);
        Task<FuelType?> GetFuelAsync(int fuelId);
        Task<GearboxType?> GetGearboxAsync(int gearboxId);
    }
}
