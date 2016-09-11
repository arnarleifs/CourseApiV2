using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException() { }

        public DuplicateException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
