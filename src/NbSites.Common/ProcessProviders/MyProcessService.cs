using System;
using System.Collections.Generic;
using System.Linq;

namespace NbSites.Common.ProcessProviders
{
    public class MyProcessService
    {
        public IEnumerable<IMyProcessProvider> Providers { get; }

        public MyProcessService(IEnumerable<IMyProcessProvider> providers)
        {
            Providers = providers.OrderBy(x => x.ProcessOrder).ToList();
        }

        public IList<IMyProcessProvider> GetProcessProviders(object context, bool nullContextThrow = false)
        {
            var myProcessProviders = new List<IMyProcessProvider>();
            if (context == null)
            {
                if (nullContextThrow)
                {
                    throw new ArgumentNullException(nameof(context));
                }
                return myProcessProviders;
            }


            foreach (var provider in Providers)
            {
                var shouldProcess = provider.ShouldProcess(context);
                if (shouldProcess)
                {
                    myProcessProviders.Add(provider);
                }
            }

            return myProcessProviders;
        }

        public void Process(object context, bool nullContextThrow = false)
        {
            var myProcessProviders = GetProcessProviders(context, nullContextThrow);
            foreach (var provider in myProcessProviders)
            {
                provider.Process(context);
            }
        }
    }
}