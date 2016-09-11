using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.Exceptions
{
    public class FullException : Exception
    {
        public FullException() { }

        public FullException(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
