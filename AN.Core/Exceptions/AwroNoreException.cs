using AN.Core.Enums;
using System;
using System.Runtime.Serialization;

namespace AN.Core.Exceptions
{
    [Serializable]
    public class AwroNoreException : Exception
    {
        public AwroNoreErrorCode ErrorCode { get; set; } = AwroNoreErrorCode.AwroNoreException;

        /// <summary>
        /// Initializes a new instance of the Exception class.
        /// </summary>
        public AwroNoreException() : base("Unknown error")
        {
        }


        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AwroNoreException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message & custom error code
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AwroNoreException(AwroNoreErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified custom error code
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AwroNoreException(AwroNoreErrorCode errorCode) : base()
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message.
        /// </summary>
        /// <param name="messageFormat">The exception message format.</param>
        /// <param name="args">The exception message arguments.</param>
        public AwroNoreException(string messageFormat, params object[] args) : base(string.Format(messageFormat, args))
        {
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        protected AwroNoreException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Only for handle Identity Errors
        /// </summary>
        /// <param name="identityError"></param>
        /// <param name="userName"></param>
        /// <param name="Email"></param>
        public AwroNoreException(string identityError, string userName, string Email) : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public AwroNoreException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

