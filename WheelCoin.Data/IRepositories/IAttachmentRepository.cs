using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface IAttachmentRepository
{
    Task<Attachment> GetAsync();
    Task CreateAsync(Attachment attachment);
    Task DeleteAsync(int id);
}