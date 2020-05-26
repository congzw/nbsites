using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NbSites.Web.Libs.Updates;

namespace NbSites.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var updateHelper = UpdateHelper.Resolve();
            if (updateHelper.NeedUpdate())
            {
                var updateResult = updateHelper.Update();
                Console.WriteLine(updateResult.Message);
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
