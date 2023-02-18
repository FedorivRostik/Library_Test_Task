using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library_Test_Task.FilterAttributes;
public class CheckSecretKeyAttribute : Attribute, IActionFilter
{
    public IConfiguration? Configuration { get; set; }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.HttpContext.Request == null)
        {
            context.Result = new BadRequestResult();
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var sercretRequest = context.HttpContext.Request.Query["secret"];

        var sercretConf = Configuration!.GetSection("SecretKey").Value.ToString();
        if (!string.Equals(sercretRequest, sercretConf, StringComparison.Ordinal))
        {
            context.Result = new BadRequestResult();
        }
    }
}
