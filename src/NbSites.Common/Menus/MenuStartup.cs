using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NbSites.Common.Modules;
using NbSites.Common.ProcessProviders;

namespace NbSites.Common.Menus
{
    public class MenuStartup : ModuleStartupBase
    {
        public override int Order { get; } = -1;

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MenuContext>();
        }
        
        public override void PostConfigureServices(IServiceProvider rootServiceProvider)
        {
            var menuContext = rootServiceProvider.GetRequiredService<MenuContext>();
            var processService = rootServiceProvider.GetRequiredService<MyProcessService>();
            processService.Process(menuContext);
        }

        public override void Configure(IApplicationBuilder builder)
        {
        }
    }
}
