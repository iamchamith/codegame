using System;
using System.Windows.Forms;

namespace BlocklyPro.Utility
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message)
        {
        }
    }

    public class InternalServerErrorException:Exception
    {
        public InternalServerErrorException(string message):base(message)
        {
        }
    }

    public class ExceptionHandler
    {
        public ExceptionHandler(Exception e)
        {
            MessageBox.Show(e.GetBaseException().Message);
        }
    }
}
