using System.Data;
using Npgsql;
using NpgsqlTypes;
using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class AttachmentRepository(string connectionString) : IAttachmentRepository
{
    public async Task<Attachment> GetAsync(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM attachments WHERE id = @id", connection))
            {
                command.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);

                var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    var attachment = MapFromReader(reader);
                    return attachment;
                }
            }
        }

        return null;
    }

    public async Task CreateAsync(Attachment attachment)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            using (NpgsqlCommand command = new NpgsqlCommand(
                       "INSERT INTO attachments (filename, filepath) VALUES (@filename, @filepath)",connection))
            {
                command.Parameters.AddWithValue("filename", NpgsqlDbType.Integer, attachment.FileName);
                command.Parameters.AddWithValue("filename", NpgsqlDbType.Integer, attachment.FilePath);

                var reader = await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM attachments WHERE id = @id;", connection))
            {
                command.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
    
    private Attachment MapFromReader(NpgsqlDataReader reader)
    {
        return new Attachment()
        {
            Id = reader.GetInt32(reader.GetOrdinal("id")),
            FileName = reader.GetString(reader.GetOrdinal("filename")),
            FilePath = reader.GetString(reader.GetOrdinal("fiepath")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdat")),
            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updatedat"))
        };
    }
}