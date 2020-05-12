using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NbSites.Areas.Web.Demo.Libs.AppServices;
using NbSites.Areas.Web.Demo.Libs.ProcessProviders;
using NbSites.Common.Modules;
using NbSites.Common.ProcessProviders;

namespace NbSites.Areas.Web.Demo.Libs.Boots
{
    public class DemoStartup : ModuleStartupBase
    {
        public override int Order { get; } = 0;

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFooSingleton, FooService>();
            services.AddScoped<IFooScoped, FooService>();
            services.AddTransient<IFooTransient, FooService>();

            services.AddTransient<IMyProcessProvider, MenuProcessProvider>();
            services.AddTransient<IMyProcessProvider, LayoutProcessProvider>();
        }

        public override void Configure(IApplicationBuilder builder)
        {
        }
    }
}
