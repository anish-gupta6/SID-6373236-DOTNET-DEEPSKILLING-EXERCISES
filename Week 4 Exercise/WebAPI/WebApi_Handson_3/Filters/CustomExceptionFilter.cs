using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Handson_3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionMessage = context.Exception.Message;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "error_log.txt");
            File.AppendAllText(filePath, $"{DateTime.Now}: {exceptionMessage}\n");

            context.Result = new ObjectResult("Internal Server Error: " + exceptionMessage)
            {
                StatusCode = 500
            };
        }
    }
}
