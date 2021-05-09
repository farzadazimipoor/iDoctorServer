using AN.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.PolyclinicMessages
{
    public partial interface IShiftCenterMessageService
    {
        Task UpdateShiftCenterMessageAsync(ShiftCenterMessage policlinicMessage);

        void UpdateShiftCenterMessage(ShiftCenterMessage policlinicMessage);

        void InsertShiftCenterMessage(ShiftCenterMessage policlinicMessage);

        IQueryable<ShiftCenterMessage> Table { get; }
    }
}
