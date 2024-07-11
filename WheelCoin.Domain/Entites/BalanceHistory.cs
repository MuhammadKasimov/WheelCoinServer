using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class BalanceHistory : Auditable
{
    public int UserId { get; set; }
    public long EarnAmount { get; set; } 
}