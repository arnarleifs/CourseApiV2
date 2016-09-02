using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CourseApi.V2.Filters
{
    public class CustomExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = "";

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(ArgumentOutOfRangeException))
            {
                message = "Index was out of range";
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(FileNotFoundException))
            {
                message = "Not found";
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(ValidationException))
            {
                message = "Object is not on the right format";
                status = HttpStatusCode.PreconditionFailed;
            }
            else
            {
                message = "";
                status = HttpStatusCode.BadRequest;
            }

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var err = message;
            response.WriteAsync(err);
            context.ExceptionHandled = true;
        }
    }
}
