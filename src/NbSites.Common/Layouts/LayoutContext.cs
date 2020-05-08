using System.Collections.Generic;
using System.Linq;

namespace NbSites.Common.Layouts
{
    public class LayoutContext
    {
        public LayoutContext(IEnumerable<ILayoutProcess> providers)
        {
            Config = new LayoutConfig();
            Init(providers);
        }

        public LayoutConfig Config { get; set; }

        protected void Init(IEnumerable<ILayoutProcess> providers)
        {
            if (providers != null)
            {
                var orderedProviders = providers.OrderBy(x => x.Order).ToList();
                foreach (var provider in orderedProviders)
                {
                    provider.Process(this);
                }
            }
        }
    }
}