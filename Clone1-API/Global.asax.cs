 
using System.Configuration;
 
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ExampleAPI.App_Start;

namespace ExampleAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            LoggerConfig.InitializeLogger();

            Microsoft.ApplicationInsights.Extensibility.
                TelemetryConfiguration.Active.InstrumentationKey = ConfigurationManager.AppSettings["iKey"];

            DependencyConfig.RegisterDependencies(GlobalConfiguration.Configuration);
        }
    }
}
