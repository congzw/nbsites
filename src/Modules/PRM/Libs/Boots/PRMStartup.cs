using Microsoft.Extensions.DependencyInjection;
using NbSites.Areas.Web.PRM.Libs.ProcessProviders;
using NbSites.Common.Modules;
using NbSites.Common.ProcessProviders;

namespace NbSites.Areas.Web.PRM.Libs.Boots
{
    public class PRMStartup : ModuleStartupBase
    {
        public override int Order { get; } = 0;

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMyProcessProvider, PRMMenuProcess>();
            //services.AddTransient<IMyProcessProvider, PRMLayoutProcess>();
        }
    }
}
