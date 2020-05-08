using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NbSites.Areas.Web.Demo.Libs.AppServices;
using NbSites.Areas.Web.Demo.Libs.Menus;
using NbSites.Common.Menus;
using NbSites.Common.Modules;

namespace NbSites.Areas.Web.Demo.Libs.Boots
{
    public class DemoStartup : IModuleStartup
    {
        public int Order { get; } = 0;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFooSingleton, FooService>();
            services.AddScoped<IFooScoped, FooService>();
            services.AddTransient<IFooTransient, FooService>();
            
            services.AddSingleton<IMenuProvider, DemoMenuProvider>();
        }

        public void Configure(IApplicationBuilder builder)
        {
        }
    }
}
