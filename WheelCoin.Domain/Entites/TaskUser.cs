using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class TaskUser : Auditable
{
    public bool IsDone { get; set; }
    public Task Task { get; set; }
    public User User { get; set; }
}