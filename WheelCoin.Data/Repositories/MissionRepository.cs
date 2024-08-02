using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Reflection;
using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class MissionRepository(string connectionString) : IMissionRepository
{
    public async Task<Mission> GetAsync(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using(var command = new NpgsqlCommand("SELECT * FROM missions WHERE id = @id;", connection))
            {
                command.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);

                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var mission = MapToMission(reader);
                    return mission;
                }
            }
            return null;
        }
    }

    public async Task<IEnumerable<Mission>> GetAllAsync()
    {
        var missions = new List<Mission>();
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("SELECT * FROM missions;", connection))
            {
                var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    var mission = MapToMission(reader);
                    missions.Add(mission);
                }
            }
        }
        return missions;
    }

    public async Task CreateAsync(Mission mission)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("INSERT INTO missions (description, name, reward, url) VALUE (@description, @name, @reward, @url);", connection))
            {
                command.Parameters.AddWithValue("description", NpgsqlDbType.Varchar, mission.Description);
                command.Parameters.AddWithValue("name", NpgsqlDbType.Varchar, mission.Name);
                command.Parameters.AddWithValue("url", NpgsqlDbType.Varchar, mission.Url);
                command.Parameters.AddWithValue("reward", NpgsqlDbType.Bigint, mission.Reward);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task UpdateAsync(int id, Mission mission)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("UPDATE missions SET description = @description, name = @name, reward = @reward, url = @url WHERE id = @id;", connection))
            {
                command.Parameters.AddWithValue("id", NpgsqlDbType.Integer, mission.Id);
                command.Parameters.AddWithValue("description", NpgsqlDbType.Varchar, mission.Description);
                command.Parameters.AddWithValue("name", NpgsqlDbType.Varchar, mission.Name);
                command.Parameters.AddWithValue("url", NpgsqlDbType.Varchar, mission.Url);
                command.Parameters.AddWithValue("reward", NpgsqlDbType.Bigint, mission.Reward);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("DELETE FROM missions WHERE id = @id;", connection))
            {
                command.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    private Mission MapToMission(NpgsqlDataReader reader)
    {
        return new Mission
        {
            Id = reader.GetInt32(reader.GetOrdinal("id")),
            Description = reader.GetString(reader.GetOrdinal("description")),
            Name = reader.GetString(reader.GetOrdinal("name")),
            Reward = reader.GetInt64(reader.GetOrdinal("ordinal")),
            Url = reader.GetString(reader.GetOrdinal("url")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdat")),
            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updatedat")),
        };
    }
}