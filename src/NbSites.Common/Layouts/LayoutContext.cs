using System;
using NbSites.Common.ProcessProviders;

namespace NbSites.Common.Layouts
{
    public class LayoutContext
    {
        public LayoutContext(MyProcessService processService, LayoutConfig config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
            processService.Process(this);
        }

        public LayoutConfig Config { get; set; }
    }
}