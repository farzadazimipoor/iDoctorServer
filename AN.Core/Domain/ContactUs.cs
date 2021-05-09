using AN.Core.Data;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Domain
{
    public partial class ContactUs : BaseEntity
    {       

        [DataType(DataType.EmailAddress)]       
        public string Email { get; set; }
        
        public string Name { get; set; }
       
        public string Mobile { get; set; }
             
        public string Topic { get; set; }
       
        public string Message { get; set; }

        public bool IsArchived { get; set; }

        public bool IsUnread { get; set; }       
    }
}
