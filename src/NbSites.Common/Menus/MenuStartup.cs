using Microsoft.Extensions.DependencyInjection;
using NbSites.Common.Modules;

namespace NbSites.Common.Menus
{
    public class MenuStartup : ModuleStartupBase
    {
        public override int Order { get; } = -1;

        public override void ConfigureServices(IServiceCollection services)
        {
            ////eg: for multi tenants
            //services.AddScoped<MenuContext>();
            services.AddSingleton<MenuContext>();
        }
    }
}
