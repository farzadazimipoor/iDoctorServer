using System.Collections.Generic;

namespace AN.Core.ViewModels
{
    public class MedicalRequestListViewModel
    {
        public int Id { get; set; }

        public string PersonName { get; set; }

        public string PersonPhone { get; set; }

        public string CountryName { get; set; }

        public int AttachmentsCount { get; set; }

        public string RequestDate { get; set; }

        public string PersonPhoneHtml { get; set; }

        public string DocumentsHtml { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class MedicalRequestDetailsViewModel
    {
        public int Id { get; set; }

        public string PersonName { get; set; }

        public string PersonPhone { get; set; }

        public string CountryName { get; set; }

        public string RequestDate { get; set; }

        public string Note { get; set; }

        public List<string> Attachments { get; set; }
    }
}
