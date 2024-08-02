using Npgsql;
using NpgsqlTypes;
using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class BalanceHistoryRepository(string connectioString) : IBalanceHistoryRepository
{
    public async Task<BalanceHistory> GetAsync(int id)
    {
        using (var connection = new NpgsqlConnection(connectioString))
        {
            using (var command = new NpgsqlCommand("SELECT * FROM balancehistory WHERE id = @id;", connection))
            {
                command.Parameters.AddWithValue("id",NpgsqlDbType.Integer, id); 
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    return MapToBalanceHistory(reader);
                }
            }
        }

        return null;
    }

    public async Task<IEnumerable<BalanceHistory>> GetAllAsync(int userId)
    {
        var balanceHistories = new List<BalanceHistory>();
        using (var connection = new NpgsqlConnection(connectioString))
        {
            using (var command = new NpgsqlCommand("SELECT * FROM balancehistory WHERE userid = @userid ORDER BY createdat DESC;", connection))
            {
                command.Parameters.AddWithValue("userid", NpgsqlDbType.Integer, userId);

                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var balanceHistory = MapToBalanceHistory(reader);
                    balanceHistories.Add(balanceHistory);
                }
            }
        }

        return balanceHistories;
    }

    public async Task CreateAsync(BalanceHistory balanceHistory)
    {
        using (var connection = new NpgsqlConnection(connectioString))
        {
            using (var command = new NpgsqlCommand("INSERT INTO balancehistories (userid, earnamount) VALUES (@userid, @earnamount);", connection))
            {
                command.Parameters.AddWithValue("userid",NpgsqlDbType.Integer, balanceHistory.UserId);
                command.Parameters.AddWithValue("earnamount",NpgsqlDbType.Bigint, balanceHistory.EarnAmount);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    private BalanceHistory MapToBalanceHistory(NpgsqlDataReader dataReader)
    {
        return new BalanceHistory()
        {
            Id = dataReader.GetInt32(dataReader.GetOrdinal("id")),
            EarnAmount = dataReader.GetInt64(dataReader.GetOrdinal("earnamount")),
            UserId = dataReader.GetInt32(dataReader.GetOrdinal("userid")),
            UpdatedAt = dataReader.GetDateTime(dataReader.GetOrdinal("updatedat")),
            CreatedAt = dataReader.GetDateTime(dataReader.GetOrdinal("createdat"))
        };
    }
}