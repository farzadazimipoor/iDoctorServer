using System.Collections.Generic;

namespace AN.BLL.Core.Appointments.InProgress
{
    public interface IIpaPoolSingleton
    {
        void Insert(IPAModel ipa);

        void Remove(IPAModel ipa);

        IEnumerable<IPAModel> GetAll();
    }
}
