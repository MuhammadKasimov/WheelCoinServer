using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class Task : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public TaskUser TaskUser { get; set; }
}
