using Npgsql;
using NpgsqlTypes;
using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class MissionUserRepository(string connectionString) : IMissionUserRepository
{
    public async Task<IEnumerable<MissionUser>> GetAllAsync(int userId)
    {
        var missionsUsers = new List<MissionUser>();
        using(var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("SELECT mu.*, m.name, m.description,m.reward m.url FROM missionsusers AS mu JOIN missions AS m ON mu.missionid = m.id WHERE userid = @userid;")) 
            {
                command.Parameters.AddWithValue("userid", NpgsqlDbType.Integer ,userId);
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync()) 
                {
                    missionsUsers.Add(MapMissionUser(reader));
                }
            }
        }
        return missionsUsers;
    }

    public async Task CreateAsync(MissionUser missionUser)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand("INSERT INTO missionsusers (missionid, userid, isdone) VALUES (@missionid,@userid,@isdone);", connection))
            {
                command.Parameters.AddWithValue("missionid",NpgsqlDbType.Integer, missionUser.MissionId);
                command.Parameters.AddWithValue("userid",NpgsqlDbType.Integer, missionUser.UserId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    private MissionUser MapMissionUser(NpgsqlDataReader reader)
    {
        return new MissionUser
        {
            Id = reader.GetInt32(reader.GetOrdinal("id")),
            IsDone = reader.GetBoolean(reader.GetOrdinal("isdone")),
            Mission = MapToMission(reader),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdat")),
            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updatedat"))       
        };
    }
    private Mission MapToMission(NpgsqlDataReader reader)
    {
        return new Mission
        {
            Id = reader.GetInt32(reader.GetOrdinal("missionid")),
            Description = reader.GetString(reader.GetOrdinal("description")),
            Name = reader.GetString(reader.GetOrdinal("name")),
            Reward = reader.GetInt64(reader.GetOrdinal("ordinal")),
            Url = reader.GetString(reader.GetOrdinal("url"))
        };
    }
}