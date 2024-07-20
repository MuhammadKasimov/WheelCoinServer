using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class MissionUserRepository : IMissionUserRepository
{
    public async Task<MissionUser> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MissionUser>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(MissionUser league)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}