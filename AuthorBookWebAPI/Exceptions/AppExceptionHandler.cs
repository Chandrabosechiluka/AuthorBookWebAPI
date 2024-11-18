using AuthorBookWebAPI.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace AuthorBookWebAPI.Exceptions
{
    public class AppExceptionHandler: IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpcontext,
            Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is AuthorNotFoundException)
            {
                response.StatusCode=StatusCodes.Status404NotFound;
                response.ExceptionMessage= exception.Message;
                response.Title = "Wrong Input";
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.ExceptionMessage = exception.Message;
                response.Title = "Something Went Wrong";
            }
            await httpcontext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
