using Identity.Core.Enums;
using System;
using System.Runtime.Serialization;

namespace Identity.Core.Exceptions
{
    [Serializable]
    public class AwronoreIdentityException : Exception
    {
        public AwronoreIdentityErrorCode ErrorCode { get; set; } = AwronoreIdentityErrorCode.Unknown;

        public AwronoreIdentityException() : base("Unknown error occurred")
        {
            ErrorCode = AwronoreIdentityErrorCode.Unknown;
        }

        public AwronoreIdentityException(AwronoreIdentityErrorCode errorCode) : base()
        {
            ErrorCode = errorCode;
        }

        public AwronoreIdentityException(AwronoreIdentityErrorCode errorCode, string content) : base(content)
        {
            ErrorCode = errorCode;
        }

        public AwronoreIdentityException(string message) : base(message)
        {
        }

        public AwronoreIdentityException(string messageFormat, params object[] args) : base(string.Format(messageFormat, args))
        {
        }

        protected AwronoreIdentityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public AwronoreIdentityException(string identityError, string userName, string Email) : base("Identity Error")
        {
        }

        public AwronoreIdentityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
