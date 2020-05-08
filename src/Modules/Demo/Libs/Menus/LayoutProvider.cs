using NbSites.Common.Layouts;

namespace NbSites.Areas.Web.Demo.Libs.Menus
{
    public class LayoutProvider : ILayoutProcess
    {
        public LayoutProvider()
        {
            Order = 1000;
        }
        public int Order { get; set; }

        public void Process(LayoutContext context)
        {
            context.Config.Layout = "_Demo/_DemoLayout";
        }
    }
}
