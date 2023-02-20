using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library_Test_Task.FilterAttributes;
public class CheckSecretKeyAttribute : Attribute, IActionFilter
{
    public IConfiguration? Configuration { get; set; }
    private readonly BadRequestResult _badRequestResult = new BadRequestResult();
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.HttpContext.Request is null)
        {
            context.Result = _badRequestResult;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!string.IsNullOrEmpty(context.HttpContext.Request.Query["secret"]))
        {
            var sercretRequest = context.HttpContext.Request.Query["secret"];
            var sercretConf = Configuration!.GetSection("SecretKey").Value.ToString();
            if (!string.Equals(sercretRequest, sercretConf, StringComparison.Ordinal))
            {
                context.Result = _badRequestResult;
            }
        }
    }
}
