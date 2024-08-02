using Npgsql;
using NpgsqlTypes;
using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class RoadmapRepository(string connectionString) : IRoadmapRepository
{
    public async Task<IEnumerable<Roadmap>> GetAllAsync()
    {
        var roadmaps = new List<Roadmap>();
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("SELECT * FROM roadmaps;"))
            {
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync()) 
                {
                    var roadmap = MapToRoadmap(reader);
                    roadmaps.Add(roadmap);
                }
            }
        }
        return roadmaps;
    }

    public async Task CreateAsync(Roadmap league)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("INSERT INTO roadmaps(step, isdone) VALUES (@step, @isdone)"))
            {
                command.Parameters.AddWithValue("step", NpgsqlDbType.Varchar, league.Step);
                command.Parameters.AddWithValue("isdone", NpgsqlDbType.Boolean, league.IsDone);
                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task UpdateAsync(int id, Roadmap league)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("UPDATE roadmaps SET step = @step, isdone = @isdone WHERE id = @id;"))
            {
                command.Parameters.AddWithValue("id", NpgsqlDbType.Varchar, id);
                command.Parameters.AddWithValue("step", NpgsqlDbType.Varchar, league.Step);
                command.Parameters.AddWithValue("isdone", NpgsqlDbType.Boolean, league.IsDone);
                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("DELETE FROM roadmaps WHERE id = @id;"))
            {
                command.Parameters.AddWithValue("id", NpgsqlDbType.Varchar, id);
   
                await command.ExecuteNonQueryAsync();
            }
        }
    }
    public Roadmap MapToRoadmap(NpgsqlDataReader reader)
    {
        return new Roadmap
        {
            Id = reader.GetInt32(reader.GetOrdinal("id")),
            Step = reader.GetString(reader.GetOrdinal("step")),
            IsDone = reader.GetBoolean(reader.GetOrdinal("isdone")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdat")),
            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("createdat")),
        };
    }
}