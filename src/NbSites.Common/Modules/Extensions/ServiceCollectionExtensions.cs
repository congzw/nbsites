﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace NbSites.Common.Modules.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IModuleServiceContext AddMyModules(this IServiceCollection services, IList<Assembly> assemblies = null, Action<IModuleServiceContext> configure = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var helper = ModuleStartupHelper.Instance;
            services.AddSingleton(helper);

            var contextInterfaceType = typeof(IModuleServiceContext);
            var context = services.LastOrDefault(d => d.ServiceType == contextInterfaceType)?.ImplementationInstance as IModuleServiceContext;
            if (context == null)
            {
                context = new DefaultModuleServiceContext()
                {
                    ApplicationServices = services
                };

                var contextDefaultImplType = context.GetType();
                services.AddSingleton(contextDefaultImplType, context);
                services.AddSingleton(contextInterfaceType, sp => sp.GetService(contextDefaultImplType));
            }
            
            if (assemblies == null)
            {
                assemblies = helper.GetAssemblies();
            }
            else
            {
                helper.GetAssemblies = () => assemblies;
            }
            services.AddAllModuleStartup(assemblies);
            
            configure?.Invoke(context);

            var provider = services.BuildServiceProvider();
            var startupModules = provider.GetServices<IModuleStartup>().OrderBy(x => x.Order).ToList();
            foreach (var startup in startupModules)
            {
                startup.PreConfigureServices();
            }

            foreach (var startup in startupModules)
            {
                startup.ConfigureServices(services);
            }

            foreach (var startup in startupModules)
            {
                startup.PostConfigureServices(services);
            }

            return context;
        }
        
        public static IMvcBuilder AddMyModulePart(this IMvcBuilder mvcBuilder)
        {
            ModuleStartupHelper.Instance.AddApplicationPart(mvcBuilder);
            return mvcBuilder;
        }

        private static void AddAllModuleStartup(this IServiceCollection services, IList<Assembly> moduleAssemblies)
        {
            if (moduleAssemblies == null)
            {
                throw new ArgumentNullException(nameof(moduleAssemblies));
            }
            
            var startupInterfaceType = typeof(IModuleStartup);
            var startupTypes = moduleAssemblies.SelectMany(x => x.ExportedTypes.Where(t => startupInterfaceType.IsAssignableFrom(t)))
                .Where(t => !t.IsAbstract && !t.IsInterface).ToList();

            foreach (var startupType in startupTypes)
            {
                services.AddSingleton(startupType);
                services.AddSingleton(startupInterfaceType, sp => sp.GetService(startupType));
            }
        }
    }
}
