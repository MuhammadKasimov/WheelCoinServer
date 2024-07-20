using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class LeagueRepository : ILeagueRepository
{
    public async Task<League> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<League>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(League league)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, League league)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}