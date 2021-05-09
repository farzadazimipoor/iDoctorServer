using AN.Core.DTO;
using AN.Core.Exceptions;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AN.BLL.Services.MedicalRequest
{
    public class MedicalRequestService : IMedicalRequestService
    {
        private readonly BanobatDbContext _dbContext;
        public MedicalRequestService(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateNewMedicalRequestAsync(string currentUsername, MedicalRequestDTO model)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == currentUsername);

            if (person == null) throw new AwroNoreException("Not any person found for this mobile number");

            var request = new AN.Core.Domain.MedicalRequest
            {
                Date = model.Date,
                Note = model.Note,
                RequestedCountryId = model.CountryId,
                RequesterPersonId = person.Id,
                CreatedAt = DateTime.Now
            };

            await _dbContext.MedicalRequests.AddAsync(request);

            await _dbContext.SaveChangesAsync();
        }
    }
}
