using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class User : Auditable
{
    public long TelegramId { get; set; }
    public string Username { get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsTelegramPremium { get; set; }
    public bool IsCreator { get; set; }
    public Attachment Attachment { get; set; }
    public League League { get; set; }  
    public Wheel Wheel { get; set; }
    public string RefereeCode { get; set; }
    public TaskUser TaskUser { get; set; }
}
