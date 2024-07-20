using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface ILeagueRepository
{
    Task<League> GetAsync(int id);
    Task<IEnumerable<League>> GetAllAsync();
    Task CreateAsync(League league);
    Task UpdateAsync(int id, League league);
    Task DeleteAsync(int id);
}