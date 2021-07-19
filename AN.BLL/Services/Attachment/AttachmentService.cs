using AN.Core.Domain;
using AN.Core.Enums;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly BanobatDbContext _dbContext;
        public AttachmentService(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Attachment>> GetAttachmentsAsync(FileOwner owner, int ownerId)
        {
            var result = await _dbContext.Attachments.Where(x => x.Owner == owner && x.OwnerTableId == ownerId).ToListAsync();

            return result;
        }

        public async Task<Attachment> GetByIdAsync(int id)
        {
            var result = await _dbContext.Attachments.FindAsync(id);

            return result;
        }
    }
}
