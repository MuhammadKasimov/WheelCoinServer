using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class MissionUser : Auditable
{
    public bool IsDone { get; set; }
    public Mission Mission { get; set; }
    public User User { get; set; }
}