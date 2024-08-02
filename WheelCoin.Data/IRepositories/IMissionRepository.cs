using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface IMissionRepository
{
    Task<Mission> GetAsync(int id);
    Task<IEnumerable<Mission>> GetAllAsync();
    Task CreateAsync(Mission mission);
    Task UpdateAsync(int id, Mission mission);
    Task DeleteAsync(int id);
}