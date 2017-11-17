using System.Configuration;
using Serilog;
using Serilog.Core;
using SerilogWeb.Classic.Enrichers;

namespace ExampleAPI.App_Start
{
    public static class LoggerConfig
    {
        public static ILogger InitializeLogger()
        {
            var iKey = ConfigurationManager.AppSettings["iKey"];

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.With<HttpRequestIdEnricher>()
                .WriteTo.Trace()
                .WriteTo.ApplicationInsightsEvents(iKey)
                .WriteTo.ApplicationInsightsTraces(iKey)
                .CreateLogger();

            return Log.Logger;
        }

    }
}