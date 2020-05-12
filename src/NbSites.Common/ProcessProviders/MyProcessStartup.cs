using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NbSites.Common.Modules;

namespace NbSites.Common.ProcessProviders
{
    public class MyProcessStartup : ModuleStartupBase
    {
        public override int Order { get; } = -1;

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MyProcessService>();
        }

        public override void Configure(IApplicationBuilder builder)
        {
        }
    }
}
