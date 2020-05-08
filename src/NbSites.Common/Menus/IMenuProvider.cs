namespace NbSites.Common.Menus
{
    public interface IMenuProvider
    {
        int Order { get; set; }
        void ProcessMenu(MenuContext menuContext);
    }
}