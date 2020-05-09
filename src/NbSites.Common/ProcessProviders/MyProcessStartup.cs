using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NbSites.Common.Modules;

namespace NbSites.Common.ProcessProviders
{
    public class MyProcessStartup : IModuleStartup
    {
        public int Order { get; } = -1;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MyProcessService>();
        }

        public void Configure(IApplicationBuilder builder)
        {
        }
    }
}
