using System.Data;
using Npgsql;
using NpgsqlTypes;
using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class LeagueRepository(string connectionString) : ILeagueRepository
{
    public async Task<League> GetAsync(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("SELECT a.id as iconid, " +
                                                   "a.filename as filename, " +
                                                   "a.filepath as filepath, " +
                                                   "a.createdat as iconcreateddate" +
                                                   "a.updatedat as iconupdatedat," +
                                                   "l.* FROM leagues as l" +
                                                   "JOIN attachments as a ON a.id = l.iconid WHERE id = @id;", connection))
            {
                command.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var league = MapReaderToLeague(reader);
                    league.Icon = MapReaderToIcon(reader);
                    return league;
                }
            }
        }
        return null;
    }

    public async Task<IEnumerable<League>> GetAllAsync()
    {
        var leagues = new List<League>();
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("SELECT * FROM leagues;", connection))
            {
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var league = MapReaderToLeague(reader);
                    league.Icon = MapReaderToIcon(reader);
                    leagues.Add(league);   
                }
            }
        }

        return leagues;
    }

    public async Task CreateAsync(League league)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("INSERT INTO attachments (filename, filepath) VALUES (@filename, @filepath);"))
            {
                command.Parameters.AddWithValue("filename", NpgsqlDbType.Varchar, league.Icon.FileName);
                command.Parameters.AddWithValue("filepath", NpgsqlDbType.Varchar, league.Icon.FilePath);

                await command.ExecuteNonQueryAsync();
            }
            using (var command = new NpgsqlCommand("INSERT INTO leagues (name, maxamount, minamount) VALUES (@name, @maxamount, @minamount);", connection))
            {
                command.Parameters.AddWithValue("name", NpgsqlDbType.Varchar, league.Name);
                command.Parameters.AddWithValue("maxamount", NpgsqlDbType.Varchar, league.MaxAmount);
                command.Parameters.AddWithValue("minamount", NpgsqlDbType.Varchar, league.MinAmount);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task UpdateAsync(int id, League league)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("UPDATE leagues SET name = @name, maxamount = @maxamount, miamount = @minamount WHERE id = @id;", connection))
            {
                command.Parameters.AddWithValue("name", NpgsqlDbType.Varchar,league.Name);
                command.Parameters.AddWithValue("maxamount", NpgsqlDbType.Bigint, league.MaxAmount);
                command.Parameters.AddWithValue("minamount", NpgsqlDbType.Bigint, league.MinAmount);
                command.Parameters.AddWithValue("id", NpgsqlDbType.Integer, league.Id);
            }
        }
    }

    public async Task DeleteAsync(int id)
    {using (var connection = new NpgsqlConnection(connectionString))
    {
        using (var command = new NpgsqlCommand("DELETE FROM leagues WHERE id = @id;", connection))
        {
            command.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);
        }
    }}

    private League MapReaderToLeague(NpgsqlDataReader reader)
    {
        return new League()
        {
            Id = reader.GetInt32(reader.GetOrdinal("id")),
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
            Id = reader.GetInt32(reader.GetOrdinal("id")),
            FileName = reader.GetString(reader.GetOrdinal("filename")),
            FilePath = reader.GetString(reader.GetOrdinal("filepath")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdat")),
            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updatedat"))
        };
    }
}