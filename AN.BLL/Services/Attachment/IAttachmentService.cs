using AN.Core.Domain;
using AN.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services
{
    public interface IAttachmentService
    {
        Task<List<Attachment>> GetAttachmentsAsync(FileOwner owner, int ownerId);

        Task<Attachment> GetByIdAsync(int id);
    }
}
