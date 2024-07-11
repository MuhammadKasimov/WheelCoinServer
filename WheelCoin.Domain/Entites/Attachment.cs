using WheelCoin.Domain.Commons;

namespace WheelCoin.Domain.Entites;

public class Attachment : Auditable
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
}
