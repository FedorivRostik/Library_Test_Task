using Library_Test_Task.FilterAttributes;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Library_Test_Task.Providers;

public class ConfigurationModelProvider : IApplicationModelProvider
{
    private readonly IConfiguration _configuration;
	public ConfigurationModelProvider(IConfiguration configuration)
	{
		_configuration= configuration;
	}

    public int Order { get { return -1000 + 10; } }

    public void OnProvidersExecuted(ApplicationModelProviderContext context)
    {
        foreach (var controllerModel in context.Result.Controllers)
        {
          /*  // pass the depencency to controller attibutes
          //  controllerModel.Attributes
          //      .OfType<CheckSecretKeyAttribute>().ToList()
          //      .ForEach(a => a.Configuration = _configuration);*/

            // pass the dependency to action attributes
            controllerModel.Actions.SelectMany(a => a.Attributes)
                .OfType<CheckSecretKeyAttribute>().ToList()
                .ForEach(a => a.Configuration = _configuration);
        }
    }

    public void OnProvidersExecuting(ApplicationModelProviderContext context)
    {
       
    }
}
