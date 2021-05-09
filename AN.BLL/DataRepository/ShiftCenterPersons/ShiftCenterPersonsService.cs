using System;
using System.Collections.Generic;
using System.Linq;
using AN.Core.Domain;
using AN.DAL;

namespace AN.BLL.DataRepository.PolyclinicUsersRepo
{
    public class ShiftCenterPersonsService : IShiftCenterPersonsService, IDisposable
    {
        private BanobatDbContext _dbContext;

        public ShiftCenterPersonsService(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IList<ShiftCenterPersons> GetAll()
        {
            return _dbContext.ShiftCenterPersons.ToList();
        }



        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.SaveChanges();
                _dbContext.Dispose();
            }

        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

}
