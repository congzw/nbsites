using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace NbSites.Common.Modules
{
    public interface IModuleStartup
    {
        /// <summary>
        /// 执行顺序 越小越靠前
        /// </summary>
        int Order { get; }

        /// <summary>
        /// DI初始化前
        /// </summary>
        void PreConfigureServices();
        /// <summary>
        /// DI初始化
        /// </summary>
        /// <param name="services"></param>
        void ConfigureServices(IServiceCollection services);
        /// <summary>
        /// DI初始化后
        /// </summary>
        /// <param name="rootServiceProvider"></param>
        void PostConfigureServices(IServiceProvider rootServiceProvider);

        /// <summary>
        /// Configure前
        /// </summary>
        /// <param name="builder"></param>
        void PreConfigure(IApplicationBuilder builder);
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder"></param>
        void Configure(IApplicationBuilder builder);
        /// <summary>
        /// Configure后
        /// </summary>
        /// <param name="builder"></param>
        void PostConfigure(IApplicationBuilder builder);
    }

    public class ModuleStartupOrder
    {
        public int Order_Core { get; set; } = 0;
        public int Order_App { get; set; } = 1000;

        public static ModuleStartupOrder Instance = new ModuleStartupOrder();
    }

    public abstract class ModuleStartupBase : IModuleStartup
    {
        /// <inheritdoc />
        public abstract int Order { get; }
        /// <inheritdoc />
        public virtual void PreConfigureServices() { }
        /// <inheritdoc />
        public abstract void ConfigureServices(IServiceCollection services);
        /// <inheritdoc />
        public virtual void PostConfigureServices(IServiceProvider rootServiceProvider) { }
        /// <inheritdoc />
        public virtual void PreConfigure(IApplicationBuilder builder) { }
        /// <inheritdoc />
        public virtual void Configure(IApplicationBuilder builder) { }
        /// <inheritdoc />
        public virtual void PostConfigure(IApplicationBuilder builder) { }
    }
}
