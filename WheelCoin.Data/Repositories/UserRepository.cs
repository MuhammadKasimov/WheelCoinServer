using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(User league)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, User league)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}