using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NbSites.Common.Modules;

namespace NbSites.Common.Layouts
{
    public class LayoutStartup : ModuleStartupBase
    {
        private readonly IConfiguration _configuration;

        public LayoutStartup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override int Order { get; } = -1;

        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<LayoutConfig>(_configuration.GetSection("LayoutConfig"));
            //use "IOptionsSnapshot<>" instead of "IOptions<>" will auto load after changed
            services.AddScoped(sp => sp.GetService<IOptionsSnapshot<LayoutConfig>>().Value);

            services.AddScoped<LayoutContext>();
        }
    }
}
