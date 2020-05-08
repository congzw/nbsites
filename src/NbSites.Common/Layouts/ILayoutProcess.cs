namespace NbSites.Common.Layouts
{
    public interface ILayoutProcess
    {
        int Order { get; set; }
        void Process(LayoutContext context);
    }
}
