using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NbSites.Areas.Web.PRM.Libs.ProcessProviders;
using NbSites.Common.Modules;
using NbSites.Common.ProcessProviders;

namespace NbSites.Areas.Web.PRM.Libs.Boots
{
    public class PRMStartup : ModuleStartupBase
    {
        private readonly IConfiguration _configuration;

        public PRMStartup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override int Order { get; } = 0;

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMyProcessProvider, PRMMenuProcess>();
            
            services.Configure<PRMConfig>(_configuration.GetSection("PRMConfig"));
            //services.AddScoped(sp => sp.GetService<IOptions<PRMConfig>>().Value); //this resolve PRMConfig will be cached!
            //services.AddSingleton(sp => sp.GetService<IOptionsSnapshot<PRMConfig>>().Value); //this will throws => Cannot resolve scoped service 'IOptionsSnapshot`1[foo]' from root provider.
            services.AddScoped(sp => sp.GetService<IOptionsSnapshot<PRMConfig>>().Value); //ok => use "IOptionsSnapshot<>" instead of "IOptions<>" will auto load after changed
        }
    }
}
