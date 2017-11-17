using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Microsoft.ApplicationInsights;
using Serilog;

namespace ExampleAPI.App_Start
{
    public class ErrorResponseExceptionHandler: IExceptionHandler
    {
        private readonly HttpConfiguration _configuration;

        public ErrorResponseExceptionHandler(HttpConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            //var logger = _configuration.DependencyResolver.GetService<ILogger>();
            //logger.Error(context.Exception, context.Exception.Message);
            //ErrorResponseHelper.WriteErrorResponse(HttpContext.Current, context.Exception);

            var ai = (TelemetryClient)_configuration.DependencyResolver.GetService(typeof(TelemetryClient));
 
            
            ai.TrackException(context.Exception);

            return Task.FromResult(context.Exception);
        }
    }
}