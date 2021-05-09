using AN.Web.Models;
using System;

namespace AN.Web.Areas.Admin.Models
{
    public class InsuranceServiceAttachmentViewModel : UploadFilesResultViewModel
    {
        public DateTime CreatedAt { get; set; }
        public int InsuranceServiceId { get; set; }
    }
}
