using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using CourseApi.V2.Models.Exceptions;

namespace CourseApi.V2.Filters
{
    public class CustomExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(ArgumentOutOfRangeException))
            {
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(ModelFormatException))
            {
                status = HttpStatusCode.PreconditionFailed;
            }
            else
            {
                status = HttpStatusCode.BadRequest;
            }

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var err = context.Exception.Message;
            response.WriteAsync(err);
            context.ExceptionHandled = true;
        }
    }
}
