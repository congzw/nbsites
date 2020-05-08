using NbSites.Common.Menus;

namespace NbSites.Areas.Web.Demo.Libs.Menus
{
    public class DemoMenuProvider : IMenuProvider
    {
        public int Order { get; set; } = 0;

        public void ProcessMenu(MenuContext menuContext)
        {
            AddDemoMenu(menuContext, "~/");
            AddDemoMenu(menuContext, "~/default/Demo/Home/Index");
            AddDemoMenu(menuContext, "~/foo/Demo/Home/Index");
            AddDemoMenu(menuContext, "~/foo/Demo/Home/Index?site=bar");
            AddDemoMenu(menuContext, "~/Demo/Home/Index");
            AddDemoMenu(menuContext, "~/Demo/Home/DiTest");
            AddDemoMenu(menuContext, "~/Space/Admin/Home/Index?site=abc&user=allen&foo=whatever");
            AddDemoMenu(menuContext, "~/index.html");
        }

        private void AddDemoMenu(MenuContext menuContext, string href)
        {
            menuContext.Menus.Add(new Menu() { FromArea = "Demo", Href = href, Key = href, ParentKey = "/", Text = href });
        }
    }
}
