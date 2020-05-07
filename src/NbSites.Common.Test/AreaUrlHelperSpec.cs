using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NbSites.Common.Web;

namespace NbSites.Common
{
    [TestClass]
    public class AreaUrlHelperSpec
    {
        [TestMethod]
        public void CreateAreaContent_Normal_ShouldOk()
        {
            var areaContentArgs = AreaContentArgs.Create().WithArea("Admin").WithContent("~/Content/css/foo.css");
            var areaUrlHelper = new AreaUrlHelper();
            areaUrlHelper.CreateAreaContent(areaContentArgs).ShouldEqual("~/Areas/Admin/Content/css/foo.css");
        }
    }
}
