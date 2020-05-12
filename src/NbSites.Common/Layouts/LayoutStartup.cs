using Microsoft.Extensions.DependencyInjection;
using NbSites.Common.Modules;

namespace NbSites.Common.Layouts
{
    public class LayoutStartup : ModuleStartupBase
    {
        public override int Order { get; } = -1;

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LayoutContext>();
        }
    }
}
