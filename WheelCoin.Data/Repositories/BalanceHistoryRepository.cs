using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class BalanceHistoryRepository : IBalanceHistoryRepository
{
    public async Task<BalanceHistory> GetAsync(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BalanceHistory>> GetAllAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(BalanceHistory balanceHistory)
    {
        throw new NotImplementedException();
    }
}