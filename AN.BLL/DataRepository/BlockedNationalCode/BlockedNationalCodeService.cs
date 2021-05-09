using AN.Core;
using AN.Core.Data;
using AN.Core.Domain;
using System.Linq;

namespace AN.BLL.DataRepository.Security
{
    public partial class BlockedMobilesService : IBlockedMobileService
    {
        private readonly IRepository<BlockedMobiles> _blockedMobileRepository;
        public BlockedMobilesService(IRepository<BlockedMobiles> blockedMobileRepository)
        {
            _blockedMobileRepository = blockedMobileRepository;
        }

        public bool IsMobileBlocked(int polyclinicId, string mobile)
        {
            if (polyclinicId == 0 || string.IsNullOrEmpty(mobile))
                return true;

            var query = _blockedMobileRepository.Table.Where(x => x.ShiftCenterId == polyclinicId && x.Mobile.Equals(mobile));

            return query.Count() >= 1;
        }
    }
}
