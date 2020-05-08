using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NbSites.Common.Modules;

namespace NbSites.Common.Menus
{
    public class MenuStartup : IModuleStartup
    {
        public int Order { get; } = -1;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MenuContext>();
        }

        public void Configure(IApplicationBuilder builder)
        {
        }
    }
}
