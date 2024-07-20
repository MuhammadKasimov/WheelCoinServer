using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class Wheel : Auditable
{
    public Attachment Image { get; set; }
    public string Name { get; set; }

    public int Price { get; set; }
    public int IncomeAmount { get; set; }
}
