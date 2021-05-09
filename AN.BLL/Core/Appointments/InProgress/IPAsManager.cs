using AN.Core.Domain;
using AN.Core.Resources.EntitiesResources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AN.BLL.Core.Appointments.InProgress
{
    /// <summary>
    /// InProgress Appointments Manager
    /// </summary>
    //قانون: هیچ دو نوبت یا بازه زمانی یکسانی درون کش ذخیره نمی شوند
    public class IPAsManager : IIPAsManager
    {
        private readonly object insertIPALock = new object();

        private readonly IIpaPoolSingleton _ipaPoolSingleton;
        public IPAsManager(IIpaPoolSingleton ipaPoolSingleton)
        {
            _ipaPoolSingleton = ipaPoolSingleton;
        }


        /// <summary>
        /// Get All inprogress apoointments from redis client pool
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPAModel> GetAll()
        {
            return _ipaPoolSingleton.GetAll();
        }


        /// <summary>
        /// Get all inprogress appointments from redis client pool for specific service supply in selected date
        /// </summary>
        /// <param name="serviceSupply"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        public IEnumerable<IPAModel> GetAll(ServiceSupply serviceSupply, DateTime Date)
        {
            return GetAll().Where(x => x.ServiceSupplyId == serviceSupply.Id && x.StartDateTime.ToShortDateString() == Date.ToShortDateString()).OrderBy(x => x.StartDateTime);
        }
       

        /// <summary>
        /// insert an inprogress appointment into redis client pool
        /// </summary>
        /// <param name="ipa">InProgress Appointment</param>
        public void Insert(IPAModel ipa)
        {
            if (Exists(ipa))
                throw new Exception(Messages.TurnIsInProgressNow);

            if (ipa.StartDateTime >= ipa.EndDateTime)
                throw new Exception(Messages.EmptyTimePeriodNotValid);

            if (ipa.StartDateTime <= DateTime.Now)
                throw new Exception(Messages.TurnTimePassed);

            try
            {
                lock (insertIPALock)
                {
                    if (Exists(ipa))
                        throw new Exception(Messages.TurnIsInProgressNow);

                    if (ipa.StartDateTime >= ipa.EndDateTime)
                        throw new Exception(Messages.EmptyTimePeriodNotValid);

                    if (ipa.StartDateTime <= DateTime.Now)
                        throw new Exception(Messages.TurnTimePassed);
                    _ipaPoolSingleton.Insert(ipa);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }       


        public void Delete(int serviceSupplyID, DateTime _StartDateTime)
        {
            var founded = GetAll().Where(x => x.ServiceSupplyId == serviceSupplyID && x.StartDateTime == _StartDateTime).FirstOrDefault();

            //if (founded == null)
            //throw new Exception("نوبت موردنظر یافت نشد");

            if (founded != null)
            {
                try
                {
                    _ipaPoolSingleton.Remove(founded);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }


        public void DeleteRange(IEnumerable<IPAModel> ipas)
        {
            try
            {
                foreach (var item in ipas)
                {
                    _ipaPoolSingleton.Remove(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
     

        public bool Exists(IPAModel ipa)
        {
            if (ipa != null)
            {
                var count = GetAll().Where(x => x.ServiceSupplyId == ipa.ServiceSupplyId && x.StartDateTime == ipa.StartDateTime).ToList().Count;

                if (count >= 1)
                    return true;
            }

            return false;
        }     
    }
}
