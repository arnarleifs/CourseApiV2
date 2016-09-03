using System;

namespace CourseApi.V2.Models.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
            Message = "Resource was not found";
        }
        public NotFoundException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
