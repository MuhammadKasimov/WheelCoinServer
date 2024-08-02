using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface IRoadmapRepository
{
    Task<IEnumerable<Roadmap>> GetAllAsync();
    Task CreateAsync(Roadmap league);
    Task UpdateAsync(int id, Roadmap league);
    Task DeleteAsync(int id);
}