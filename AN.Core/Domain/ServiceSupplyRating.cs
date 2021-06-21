using AN.Core.Data;

namespace AN.Core.Domain
{
    public class ServiceSupplyRating : BaseEntity
    {       
        public int? AppointmentId { get; set; }

        public int PersonId { get; set; }              

        public int ServiceSupplyId { get; set; }

        public double Rating { get; set; }

        public string Review { get; set; }

        public virtual Person Person { get; set; }

        public virtual Appointment Appointment { get; set; }

        public virtual ServiceSupply ServiceSupply { get; set; }
    }
}
