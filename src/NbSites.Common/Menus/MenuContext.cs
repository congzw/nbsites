using System.Collections.Generic;
using NbSites.Common.ProcessProviders;

namespace NbSites.Common.Menus
{
    public class MenuContext
    {
        public MenuContext(MyProcessService processService)
        {
            Menus = new List<Menu>();
            processService.Process(this);
        }

        public IList<Menu> Menus { get; set; }
    }
}