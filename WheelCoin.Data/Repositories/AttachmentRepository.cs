using WheelCoin.Data.IRepositories;
using WheelCoin.Domain.Entites;

namespace WheelCoin.Data.Repositories;

public class AttachmentRepository : IAttachmentRepository
{
    public async Task<Attachment> GetAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(Attachment attachment)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}