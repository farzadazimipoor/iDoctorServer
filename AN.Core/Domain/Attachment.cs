using AN.Core.Data;
using AN.Core.Enums;

namespace AN.Core.Domain
{
    public class Attachment : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Url { get; set; }
        public double Size { get; set; }
        public string DeleteUrl { get; set; }
        public FileType FileType { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Owner Table
        /// </summary>
        public FileOwner Owner { get; set; }

        /// <summary>
        /// Id Of Owner (Related) Table
        /// </summary>
        public int OwnerTableId { get; set; }
    }
}
