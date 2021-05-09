using AN.Core.Data;
using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.ContactUsRepo
{
    public partial class ContactUsService : IContactUsService
    {
        private readonly IRepository<ContactUs> _contactUsRepository;
        public ContactUsService(IRepository<ContactUs> contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public IQueryable<ContactUs> Table => _contactUsRepository.Table;

        public async Task<ContactUs> GetByIAsync(int id)
        {
            var result = await Table.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task InsertNewAsync(ContactUs contactUs)
        {
            await _contactUsRepository.InsertAsync(contactUs);
        }

        public async Task ReadAsync(int id, bool isRead = true)
        {
            var message = await Table.FirstOrDefaultAsync(x => x.Id == id);

            if (message == null) throw new Exception("Message Not Found");

            message.IsUnread = isRead == false;

            _contactUsRepository.Update(message);           
        }

        public async Task ArchiveAsync(int id, bool isArchived = true)
        {
            var message = await Table.FirstOrDefaultAsync(x => x.Id == id);

            if (message == null) throw new Exception("Message Not Found");

            message.IsArchived = isArchived;

            _contactUsRepository.Update(message);
        }

        public async Task DeleteAsync(int id)
        {
            var message = await Table.FirstOrDefaultAsync(x => x.Id == id);

            if (message != null)
            {
                await _contactUsRepository.DeleteAsync(message);
            }           
        }


        public IEnumerable<ContactUs> GetAll()
        {
            return _contactUsRepository.Table;
        }

        public virtual async Task<int> GetAllUnreadMessagesCountAsync()
        {
            return await _contactUsRepository.Table.Where(x => x.IsUnread && !x.IsArchived).CountAsync();
        }
    }
}
