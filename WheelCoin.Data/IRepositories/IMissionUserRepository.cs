using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface IMissionUserRepository
{
    Task<IEnumerable<MissionUser>> GetAllAsync(int userId);
    Task CreateAsync(MissionUser missionUser);
}