using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class WheelRepository : IWheelRepository
{
    public async Task<Wheel> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Wheel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(Wheel league)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, Wheel league)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}