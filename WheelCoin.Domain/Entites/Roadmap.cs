using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class Roadmap : Auditable
{
    public string Step { get; set; }
    public bool IsDone { get; set; }
}
