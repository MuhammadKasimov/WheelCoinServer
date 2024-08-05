using Npgsql;
using NpgsqlTypes;
using System.Data;
using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class WheelRepository(string connectionString) : IWheelRepository
{
    public async Task<Wheel> GetAsync(int id)
    {
        using (var connection  = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("SELECT w.*, a.filename,a.filepath FROM wheels AS w JOIN attachments AS a ON w.attachmentid = a.id WHERE id = @id;"))
            {
                command.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);

                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    return MapReaderToWheel(reader);
                }
            }
        }
        return null;
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

    private Wheel MapReaderToWheel(NpgsqlDataReader reader)
    {
        return new Wheel
        {
            Id = reader.GetInt32(reader.GetOrdinal("id")),
            Image = MapReaderToIcon(reader),
            IncomeAmount = reader.GetInt64(reader.GetOrdinal("incomeamount")),
            Name = reader.GetString(reader.GetOrdinal("name")),
            Price = reader.GetInt64(reader.GetOrdinal("price")),
            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updatedat")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdat"))
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