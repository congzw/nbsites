namespace NbSites.Web.Libs.Helpers
{
    public class LayoutConfig
    {
        public LayoutConfig()
        {
            Layout = "_Layout";
        }

        public string Layout { get; set; }
    }

    public interface IMyWebHelper
    {
        LayoutConfig GetLayoutConfig();
    }

    public class MyWebHelper : IMyWebHelper
    {
        public LayoutConfig GetLayoutConfig()
        {
            //todo
            //Layout = "_Basic/_BasicLayout";
            //Layout = "_Ace/_AceLayout";
            return new LayoutConfig();
        }
    }
}
