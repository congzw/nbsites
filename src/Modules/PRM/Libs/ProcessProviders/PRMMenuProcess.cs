using NbSites.Common.Menus;
using NbSites.Common.ProcessProviders;

namespace NbSites.Areas.Web.PRM.Libs.ProcessProviders
{
    public class PRMMenuProcess : IMyProcessProvider
    {
        public float ProcessOrder { get; set; }

        public bool ShouldProcess(object context)
        {
            return context is MenuContext;
        }

        public void Process(object context)
        {
            var menuContext = context as MenuContext;
            if (menuContext == null)
            {
                return;
            }

            AddDemoMenu(menuContext, "~/PRM/Home/Index");
        }

        private void AddDemoMenu(MenuContext menuContext, string href)
        {
            menuContext.Menus.Add(new Menu() { FromArea = "PRM", Href = href, Key = href, ParentKey = "/", Text = href });
        }
    }
}
