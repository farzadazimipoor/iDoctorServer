namespace AN.Core.Enums
{
    public enum ConsultancyStatus
    {
        /// <summary>
        /// When user create new chat
        /// </summary>
        NEW = 0,

        /// <summary>
        /// When doctor start chat
        /// </summary>
        STARTED = 1,

        /// <summary>
        /// When doctor finish chat
        /// </summary>
        FINISHED = 2,

        /// <summary>
        /// When doctor remove chat for itself
        /// </summary>
        REMOVED_BY_DOCTOR = 3
    }

	public enum ConsultancyMessageType
    {
		TEXT = 0,
		PHOTO = 1,
		VOICE = 2,
		VIDEO = 3,
		GIF = 4
    }

    public enum ConsultancyMessageStatus
    {
        NEW = 0,
        DELIVERED = 1,
        READ = 2,
        DELETED = 3,
    }

    public enum ConsultancyMessageSender
    {
        CONSULTANT = 0,
        CUSTOMER = 1
    }

    public enum MessageSenderReceiverType
    {
        SENT = 0,
        RECEIVED = 1
    }
}
