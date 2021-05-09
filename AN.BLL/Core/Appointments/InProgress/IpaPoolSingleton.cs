using System.Collections.Generic;
using System.Linq;

namespace AN.BLL.Core.Appointments.InProgress
{
    public class IpaPoolSingleton : IIpaPoolSingleton
    {
        private readonly object reserveLock = new object();      

        private readonly List<IPAModel> IPA_Pool = new List<IPAModel>();

        public void Insert(IPAModel ipa)
        {
            lock (reserveLock)
            {
                IPA_Pool.Add(ipa);
            }            
        }

        public void Remove(IPAModel ipa)
        {
            IPA_Pool.Remove(ipa);
        }

        public IEnumerable<IPAModel> GetAll()
        {
            return IPA_Pool.OrderBy(x => x.StartDateTime);
        }
        
    }
}
