using AN.Core.DTO.Profile;
using AN.Core.Enums;
using System.Collections.Generic;

namespace AN.Core.DTO.Consultancy
{
    public class ConsultancyGroupDTO : BaseDTO
    {
        public string Title { get; set; }      
        public List<ConsultancyGroupDoctorDTO> Doctors { get; set; }
    }

    public class ConsultancyGroupDoctorDTO : BaseDTO
    {
        public string Fullname { get; set; }      
        public string Avatar { get; set; }      
    }

    public class ConsultancyGroupsResultDTO
    {      
        public int TotalCount { get; set; }
        public List<ConsultancyGroupDTO> ConsultancyGroups { get; set; }
    }

    public class ConsultancyDoctorItemDTO : BaseDTO
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Speciality { get; set; }
        public double AverageRating { get; set; }
        public int Questions { get; set; }
    }

    public class ConsultancyDoctorChatItemDTO : ConsultancyDoctorItemDTO
    {
        public string LastMessage { get; set; }
        public bool Seen { get; set; }
        public bool HasUnSeenMessages { get; set; }
        public int UnSeenCount { get; set; }
        public string LastMessageTime { get; set; }
        public bool IsOnline { get; set; }
    }

    public class ConsultancyDoctorsResultDTO
    {
        public int TotalCount { get; set; }
        public List<ConsultancyDoctorChatItemDTO> ConsultancyDoctors { get; set; }
    }

    /// <summary>
    /// Details of consultant (Like doctor details tab)
    /// </summary>
    public class ConsultantDetailsDTO
    {

    }

    /// <summary>
    /// Details for consultancy with each doctor
    /// </summary>
    public class UserConsultancyDetailsDTO
    {
        public int PersonId { get; set; }

        public int ServiceSupplyId { get; set; }

        /// <summary>
        /// Total chats count with each doctor
        /// </summary>
        public int TotalChatsCount { get; set; }

        /// <summary>
        /// Number of chats with each doctor that has been completed
        /// </summary>
        public int FinishedChatsCount { get; set; }

        /// <summary>
        /// This is latest open chat id (Not finished yet)
        /// </summary>
        public int? CurrentChatId { get; set; }
    }

    public class ConsultancyMessageDTO
    {
        public int Id { get; set; }
        public MessageSenderReceiverType SenderReceiverType { get; set; }
        public string ContactAvatar { get; set; }
        public string ContactName { get; set; }
        public string Message { get; set; }
        public string Time { get; set; }
        public ConsultancyMessageType Type { get; set; }
    }

    public class ConsultancyChatDTO
    {
        public int Id { get; set; }
        public ConsultancyStatus Status { get; set; }
        public string ChatScreenMention { get; set; }
        /// <summary>
        /// Will show under contact name in chat screen
        /// </summary>
        public string ContactStatus { get; set; }
        public List<ConsultancyMessageDTO> Messages { get; set; }
        public DiseaseRecordsFormDTO DiseaseRecordsForm { get; set; }
    }

    public class DoctorConsultancyChatDTO
    {
        public int Id { get; set; }

        public ConsultancyStatus Status { get; set; }

        public string StartedAt { get; set; }

        public string FinishedAt { get; set; }

        public int ServiceSupplyId { get; set; }

        public int PersonId { get; set; }

        public string ChatScreenMention { get; set; }

        /// <summary>
        /// Will show under contact name in chat screen
        /// </summary>
        public string ContactStatus { get; set; }

        public List<ConsultancyMessageDTO> Messages { get; set; }

        public DiseaseRecordsFormDTO DiseaseRecordsForm { get; set; }
    }

    public class SendMessageDTO
    {
        public int ConsultancyId { get; set; }
        public int PersonId { get; set; }
        public int ServiceSupplyId { get; set; }
        public ConsultancyMessageSender Sender { get; set; }
        public ConsultancyMessageType Type { get; set; }
        public string Content { get; set; }
    }

    public class ConsultantChatsFilterModel
    {
        public ConsultancyStatus Status { get; set; }
    }

    public class MyChatsFilterModel
    {
        public ConsultancyStatus? Status { get; set; }
        public int? ServiceSupplyId { get; set; }
    }

    public class ConsultantChatsDTO : BaseDTO
    {
        public ConsultancyStatus Status { get; set; }

        public string StartedAt { get; set; }

        public string FinishedAt { get; set; }

        public int ServiceSupplyId { get; set; }

        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string PersonAvatar { get; set; }

        public string LastMessage { get; set; }
    }

    public class ConsultantChatsResultDTO
    {
        public int TotalCount { get; set; }
        public List<ConsultantChatsDTO> Chats { get; set; }
    }
}
