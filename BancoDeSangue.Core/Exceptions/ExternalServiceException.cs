using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Core.Exceptions
{
    public class ExternalServiceException : Exception
    {
        public ExternalServiceException(string message) : base(message)
        {
        }
    }
}
