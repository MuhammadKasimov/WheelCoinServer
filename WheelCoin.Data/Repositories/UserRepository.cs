using Npgsql;
using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class UserRepository(string connectionString) : IUserRepository
{
    public async Task<User> GetAsync(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("SELECT * FROM users WHERE id = @id", connection)) 
            {
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync()) 
                {
                    throw new NotImplementedException();
                }
            }
        }
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

    private User CreateUser(NpgsqlDataReader reader)
    {
        return new User
        {
            Id = reader.GetInt32(reader.GetOrdinal("id")),
            LastName = reader.GetString(reader.GetOrdinal("lastname")),
            FirstName = reader.GetString(reader.GetOrdinal("firstname")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdat")),
            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updatedat")),
            IsCreator = reader.GetBoolean(reader.GetOrdinal("iscreator")),
            RefereeCode = reader.GetString(reader.GetOrdinal("refereecode")),
            TelegramId = reader.GetInt64(reader.GetOrdinal("telegramid")),
            Username = reader.GetString(reader.GetOrdinal("username")),
            WalletAddress = reader.GetString(reader.GetOrdinal("walletaddress")),
            Wheel = MapReaderToWheel(reader),
            IsTelegramPremium = reader.GetBoolean(reader.GetOrdinal("istelegrampremium")),
            League = MapReaderToLeague(reader),
            Attachment = MapReaderToIcon(reader)
        };
    }
    private Wheel MapReaderToWheel(NpgsqlDataReader reader) 
    {
        return new Wheel
        {
            Id = reader.GetInt32(reader.GetOrdinal("wheelid")),
            Image = MapReaderToIcon(reader),
            Name = reader.GetString(reader.GetOrdinal("name")),
            IncomeAmount = reader.GetInt64(reader.GetOrdinal("incomeamount")),
            Price = reader.GetInt64(reader.GetOrdinal("price")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdat"))
            //not finished
        };
    }
    private League MapReaderToLeague(NpgsqlDataReader reader)
    {
        return new League()
        {
            Id = reader.GetInt32(reader.GetOrdinal("leagueid")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdat")),
            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updatedat")),
            Name = reader.GetString(reader.GetOrdinal("name")),
            MaxAmount = reader.GetInt64(reader.GetOrdinal("maxamout")),
            MinAmount = reader.GetInt64(reader.GetOrdinal("maxamount"))
        };
    }
    private Attachment MapReaderToIcon(NpgsqlDataReader reader)
    {
        return new Attachment()
        {
            Id = reader.GetInt32(reader.GetOrdinal("attachmentid")),
            FileName = reader.GetString(reader.GetOrdinal("filename")),
            FilePath = reader.GetString(reader.GetOrdinal("filepath")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdat")),
            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updatedat"))
        };
    }
}