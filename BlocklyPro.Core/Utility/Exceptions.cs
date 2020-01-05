using System;

namespace BlocklyPro.Core.Utility
{
    public class InvalidDataException:Exception
    {
        public InvalidDataException():base("Invalid data")
        {
        }

        public InvalidDataException(string message):base(message)
        {
            
        }
    }

    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException() : base("Record not founded")
        {
        }

        public RecordNotFoundException(string message) : base(message)
        {

        }
    }
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("Unauthorized")
        {
        }

        public UnauthorizedException(string message) : base(message)
        {

        }
    }
}
