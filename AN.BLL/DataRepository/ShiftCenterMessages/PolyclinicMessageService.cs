using AN.Core.Data;
using AN.Core.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.PolyclinicMessages
{
    public partial class ShiftCenterMessageService : IShiftCenterMessageService
    {
        private readonly IRepository<ShiftCenterMessage> _shiftCenterMessageRepository;

        public ShiftCenterMessageService(IRepository<ShiftCenterMessage> shiftCenterMessageRepository)
        {
            _shiftCenterMessageRepository = shiftCenterMessageRepository;
        }


        public IQueryable<ShiftCenterMessage> Table
        {
            get { return _shiftCenterMessageRepository.Table; }
        }

        public virtual void InsertShiftCenterMessage(ShiftCenterMessage policlinicMessage)
        {
            if (policlinicMessage == null)
                throw new ArgumentNullException("policlinicMessage");

            _shiftCenterMessageRepository.Insert(policlinicMessage);
        }

        public virtual void UpdateShiftCenterMessage(ShiftCenterMessage policlinicMessage)
        {
            if (policlinicMessage == null)
                throw new ArgumentNullException("policlinicMessage");

            _shiftCenterMessageRepository.Update(policlinicMessage);
        }

        public Task UpdateShiftCenterMessageAsync(ShiftCenterMessage policlinicMessage)
        {
            throw new NotImplementedException();
        }
    }
}
