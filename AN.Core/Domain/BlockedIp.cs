using AN.Core.Data;

namespace AN.Core.Domain
{
    public class BlockedIp : BaseEntity
    {       
        public string IpAddress { get; set; }
    }
}
