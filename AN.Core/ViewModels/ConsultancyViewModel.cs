using AN.Core.Enums;
using AN.Core.Resources.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AN.Core.ViewModels
{
    public class ConsultancyChatsListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public string Doctor { get; set; }

        [Display(Name = "Patient", ResourceType = typeof(Global))]
        public string Patient { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Global))]
        public string Status { get; set; }

        [Display(Name = "CreateDate", ResourceType = typeof(Global))]
        public string CreateDate { get; set; }

        public string StartDate { get; set; }

        public string FinishDate { get; set; }

        public int MessagesCount { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class ConsultancyChatsFilterViewModel
    {
        public int? ServiceSupplyId { get; set; }

        public int? PersonId { get; set; }

        public string FilterString { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public ConsultancyStatus? Status { get; set; }
    }

    public class MessageItemViewModel
    {
        public string DoctorAvatar { get; set; }
        public string Doctor { get; set; }
        public string Person { get; set; }
        public string PersonAvatar { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }
        public ConsultancyMessageType Type { get; set; }

        public ConsultancyMessageStatus Status { get; set; }

        public ConsultancyMessageSender Sender { get; set; }
    }

    public class ChatDetailsViewModel
    {
        public string Doctor { get; set; }
        public string DoctorAvatar { get; set; }
        public string Person { get; set; }
        public string PersonAvatar { get; set; }
        public string Date { get; set; }
        public ConsultancyStatus Status { get; set; }
        public int MessagesCount { get; set; }
    }
}
