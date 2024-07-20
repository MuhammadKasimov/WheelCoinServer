using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class MissionRepository : IMissionRepository
{
    public async Task<Mission> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Mission>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(Mission league)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, Mission league)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}