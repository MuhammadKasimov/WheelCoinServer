using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface IMissionUserRepository
{
    Task<MissionUser> GetAsync(int id);
    Task<IEnumerable<MissionUser>> GetAllAsync();
    Task CreateAsync(MissionUser league);
    Task DeleteAsync(int id);
}