using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using ExampleAPI.App_Start;

namespace ExampleAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Services.Add(typeof(IExceptionLogger), new AiExceptionLogger(config));

            //Investigate if this can is interfering with AI exception logger
            config.Services.Replace(typeof(IExceptionHandler), new ErrorResponseExceptionHandler(config));
        }
    }

    
}
