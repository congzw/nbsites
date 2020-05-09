using NbSites.Common.ProcessProviders;

namespace NbSites.Common.Layouts
{
    public class LayoutContext
    {
        public LayoutContext(MyProcessService processService)
        {
            Config = new LayoutConfig();
            processService.Process(this);
        }

        public LayoutConfig Config { get; set; }
    }
}