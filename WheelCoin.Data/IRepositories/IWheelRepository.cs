using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface IWheelRepository
{
    Task<Wheel> GetAsync(int id);
    Task<IEnumerable<Wheel>> GetAllAsync();
    Task CreateAsync(Wheel league);
    Task UpdateAsync(int id, Wheel league);
    Task DeleteAsync(int id);
}