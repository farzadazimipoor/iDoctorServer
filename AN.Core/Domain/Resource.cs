using AN.Core.Data;
using AN.Core.Enums;

namespace AN.Core.Domain
{
    public class Resource : BaseEntity
    {              
        public ResourceKey Key { get; set; }

        public ResourceType Type { get; set; }

        public string FilePath { get; set; }

        public int Downloads { get; set; }
       
        public string Version { get; set; }       
    }
}
