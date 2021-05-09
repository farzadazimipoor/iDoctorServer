using AN.Core.Domain;
using System;
using System.Collections.Generic;

namespace AN.BLL.Core.Appointments.InProgress
{
    public interface IIPAsManager
    {
        IEnumerable<IPAModel> GetAll();

        IEnumerable<IPAModel> GetAll(ServiceSupply serviceSupply, DateTime Date);

        void Insert(IPAModel InProgressAppointment);

        void Delete(int serviceSupplyID, DateTime _StartDateTime);

        void DeleteRange(IEnumerable<IPAModel> ipas);

        bool Exists(IPAModel ipa);
    }
}
