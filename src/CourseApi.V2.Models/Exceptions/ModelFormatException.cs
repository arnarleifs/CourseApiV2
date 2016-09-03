using System;

namespace CourseApi.V2.Models.Exceptions
{
    public class ModelFormatException : Exception
    {
        public ModelFormatException()
        {
            Message = "The model was not on the correct format";
        }
        public ModelFormatException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
