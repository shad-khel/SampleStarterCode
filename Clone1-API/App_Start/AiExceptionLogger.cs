using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Microsoft.ApplicationInsights;

namespace ExampleAPI.App_Start
{
    public class AiExceptionLogger : ExceptionLogger
    {
        private readonly HttpConfiguration _configuration;
        public AiExceptionLogger(HttpConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            var ai = (TelemetryClient)_configuration.DependencyResolver.GetService(typeof(TelemetryClient));

            if (context != null && context.Exception != null)
            {//or reuse instance (recommended!). see note above
                //var ai = new TelemetryClient();
                ai.TrackException(context.Exception);
            }
            base.Log(context);
        }
    }
}