using AN.Core.Exceptions;
using AN.Core.Resources.EntitiesResources;
using System;
using System.Runtime.Serialization;

namespace AN.Core.MyExceptions
{
    [Serializable]
    public class AccessDeniedException : AwroNoreException
    {
        public AccessDeniedException() : base(Messages.AccessDenied)
        {
            ErrorCode = Enums.AwroNoreErrorCode.AccessDenied;
        }

        public AccessDeniedException(string message) : base(message)
        {
            ErrorCode = Enums.AwroNoreErrorCode.AccessDenied;
        }
    }

    [Serializable]
    public class NotValidMobileException : AwroNoreException
    {
        public NotValidMobileException()
        {
            ErrorCode = Enums.AwroNoreErrorCode.UserMobileIsNull;
        }

        public NotValidMobileException(string mobile) : base(Messages.MobileIsNotValid + ": " + mobile)
        {
            ErrorCode = Enums.AwroNoreErrorCode.UserMobileIsNull;
        }
    }


    [Serializable]
    public class InCorrectMobileException : AwroNoreException
    {
        public InCorrectMobileException() : base(Messages.MobileIsNotValid)
        {

        }

        public InCorrectMobileException(string mobile) : base(Messages.MobileIsNotValid + ": " + mobile)
        {

        }
    }


    [Serializable]
    public class ScheduleForPastException : AwroNoreException
    {
        public ScheduleForPastException() : base(Messages.ScheduleForPastException)
        {

        }

        public ScheduleForPastException(string scheudle) : base($"{Messages.ScheduleForPastException}: {scheudle}")
        {

        }
    }



    [Serializable]
    public class ScheduleForVocationDayException : AwroNoreException
    {
        public ScheduleForVocationDayException() : base(Messages.ScheduleForVocationDayException)
        {

        }
        public ScheduleForVocationDayException(string date) : base($"{Messages.ScheduleForVocationDayException}: {date}")
        {

        }
    }

    [Serializable]
    public class ScheduleForDisabledDayException : AwroNoreException
    {
        public ScheduleForDisabledDayException() : base(Messages.ScheduleForDisabledDayException)
        {

        }

        public ScheduleForDisabledDayException(string date) : base($"{Messages.ScheduleForDisabledDayException}: {date}")
        {

        }
    }


    [Serializable]
    public class ScheduleForNotWorkingHoursException : AwroNoreException
    {
        public ScheduleForNotWorkingHoursException() : base(Messages.ScheduleForNotWorkingHoursException)
        {

        }
    }


    [Serializable]
    public class ScheduleOutsideBoundException : AwroNoreException
    {
        public ScheduleOutsideBoundException() : base(Messages.ScheduleOutsideBoundException)
        {

        }
    }


    [Serializable]
    public class NotFoundValidScheduleException : AwroNoreException
    {
        public NotFoundValidScheduleException() : base(Messages.NotFoundValidScheduleException)
        {

        }

        public NotFoundValidScheduleException(string date) : base($"{Messages.NotFoundValidScheduleException}: {date}")
        {

        }
    }


    [Serializable]
    public class DeleteCurrentUserException : AwroNoreException
    {
        public DeleteCurrentUserException() : base(Messages.DeleteCurrentUserException)
        {

        }
    }


    [Serializable]
    public class UnAssignDoctorWithPendingAppointmentsException : AwroNoreException
    {
        public UnAssignDoctorWithPendingAppointmentsException() : base(Messages.UnAssignDoctorWithPendingAppointmentsException)
        {

        }
        public UnAssignDoctorWithPendingAppointmentsException(string doctorName, int numberOfAppintments) : base($"{Messages.UnAssignDoctorWithPendingAppointmentsException}: {numberOfAppintments}")
        {

        }
    }


    [Serializable]
    public class HavePendingAppointmentsException : AwroNoreException
    {
        public HavePendingAppointmentsException()
        {

        }
    }


    [Serializable]
    public class SystemVocationDayException : AwroNoreException
    {
        public SystemVocationDayException(): base(Messages.SystemVocationDayException)
        {

        }

        public SystemVocationDayException(string date, string dayofweek): base($"{Messages.SystemVocationDayException} : {dayofweek}-{date}")
        {

        }
    }


    [Serializable]
    public class EntityNotFoundException : AwroNoreException
    {
        public Type EntityType { get; set; }
        public object Id { get; set; }
        public EntityNotFoundException() : base(Messages.EntityNotFoundException)
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {

        }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public EntityNotFoundException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
        public EntityNotFoundException(Type entityType, object id)
            : this(entityType, id, null)
        {

        }
        public EntityNotFoundException(Type entityType, object id, Exception innerException)
            : base($"There is no such an entity. Entity type: {entityType.FullName}, id: {id}", innerException)
        {
            EntityType = entityType;
            Id = id;
        }
    }
}
