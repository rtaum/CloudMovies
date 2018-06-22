using Microsoft.AspNetCore.Mvc.Filters;

namespace CloudMovies.Service.Filters
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
        }
    }
}
