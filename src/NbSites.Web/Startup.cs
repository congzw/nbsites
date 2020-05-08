using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NbSites.Common.Modules.Extensions;

namespace NbSites.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMyModules();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMyModules();
        }
    }
}