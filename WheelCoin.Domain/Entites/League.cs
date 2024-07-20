using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class League : Auditable
{
    public string Name { get; set; }
    public long MinAmount { get; set; }
    public long? MaxAmount { get; set; }
    public Attachment Icon { get; set; }
}
