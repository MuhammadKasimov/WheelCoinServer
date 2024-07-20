using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class Wheel : Auditable
{
    public Attachment Image { get; set; }
    public string Name { get; set; }
    public long Price { get; set; }
    public long IncomeAmount { get; set; }
}
