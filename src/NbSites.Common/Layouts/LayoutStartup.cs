using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NbSites.Common.Modules;

namespace NbSites.Common.Layouts
{
    public class LayoutStartup : IModuleStartup
    {
        public int Order { get; } = -1;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LayoutContext>();
        }

        public void Configure(IApplicationBuilder builder)
        {
        }
    }
}
