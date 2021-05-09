namespace AN.BLL.DataRepository.Security
{
    public partial interface IBlockedMobileService
    {
        bool IsMobileBlocked(int polyclinicId, string mobile);
    }
}
