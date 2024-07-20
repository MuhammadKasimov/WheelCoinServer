using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface IUserRepository
{
    Task<User> GetAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task CreateAsync(User league);
    Task UpdateAsync(int id, User league);
    Task DeleteAsync(int id);
}