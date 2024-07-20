using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.IRepositories;

public interface IAttachmentRepository
{
    Task<Attachment> GetAsync(int id);
    Task CreateAsync(Attachment attachment);
    Task DeleteAsync(int id);
}