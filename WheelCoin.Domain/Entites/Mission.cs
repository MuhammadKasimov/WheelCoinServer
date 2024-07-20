using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class Mission : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public MissionUser MissionUser { get; set; }
}
