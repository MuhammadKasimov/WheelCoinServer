using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class RoadmapRepository : IRoadmapRepository
{
    public async Task<Roadmap> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Roadmap>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(Roadmap league)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, Roadmap league)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}