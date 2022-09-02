using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi._Configuration
{
    public class AuthorizeWithKeyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var clienteKey = context.HttpContext.Request.Headers["Client-Key"].ToString();

            if (string.IsNullOrWhiteSpace(clienteKey))
            {
                context.Result = new UnauthorizedObjectResult(null);
            }

            base.OnActionExecuting(context);
        }
    }
}
