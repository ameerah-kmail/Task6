using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Task4_userAPI.Filters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var auth = context.HttpContext.Request.Headers["Role"];
            if (auth == "admin")
            {
                return;
            }
            else
            {
                context.Result = new BadRequestObjectResult("You Are Not An Admin");
                return;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
