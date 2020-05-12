using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace NbSites.Common.Modules.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMyModules(this IApplicationBuilder app, Action<IApplicationBuilder> configure = null)
        {
            var startUps = app.ApplicationServices.GetServices<IModuleStartup>().OrderBy(x => x.Order).ToList();

            foreach (var startup in startUps)
            {
                startup.PreConfigure(app);
            }

            foreach (var startup in startUps)
            {
                startup.Configure(app);
            }

            foreach (var startup in startUps)
            {
                startup.PostConfigure(app);
            }

            configure?.Invoke(app);
            return app;
        }
    }
}
