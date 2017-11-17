using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.ApplicationInsights;
using Serilog;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace ExampleAPI.App_Start
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies(HttpConfiguration configuration)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register(() => Log.Logger);
            container.Register<TelemetryClient>(() => new TelemetryClient(), Lifestyle.Singleton );

            container.Verify();
            configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}