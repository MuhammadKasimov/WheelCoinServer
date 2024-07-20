using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface IMissionRepository
{
    Task<Mission> GetAsync(int id);
    Task<IEnumerable<Mission>> GetAllAsync();
    Task CreateAsync(Mission league);
    Task UpdateAsync(int id, Mission league);
    Task DeleteAsync(int id);
}