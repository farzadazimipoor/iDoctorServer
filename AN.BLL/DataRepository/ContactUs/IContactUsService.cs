using AN.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.ContactUsRepo
{
    public partial interface IContactUsService
    {
        IQueryable<ContactUs> Table { get; }

        Task<ContactUs> GetByIAsync(int id);

        Task InsertNewAsync(ContactUs contactUs);

        Task ReadAsync(int id, bool isRead = true);

        Task ArchiveAsync(int id, bool isArchived = true);

        Task DeleteAsync(int id);

        IEnumerable<ContactUs> GetAll();

        Task<int> GetAllUnreadMessagesCountAsync();
    }
}
