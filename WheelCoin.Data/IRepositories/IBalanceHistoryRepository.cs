using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface IBalanceHistoryRepository
{
    Task<BalanceHistory> GetAsync(int id, int userId);
    Task<IEnumerable<BalanceHistory>> GetAllAsync(int userId);
    Task CreateAsync(BalanceHistory balanceHistory);
}