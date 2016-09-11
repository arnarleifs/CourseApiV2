using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.Exceptions
{
    public class FullException : Exception
    {
        public FullException()
        {
            Message = "The resource you are adding to is full.";
        }

        public FullException(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
