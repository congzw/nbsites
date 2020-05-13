using System;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NbSites.Common.ReleaseManage.Mocks;

namespace NbSites.Common.ReleaseManage
{
    [TestClass]
    public class ReleaseManagerSpec
    {
        [TestMethod]
        public void GetProducts_ArgsNull_Should_Throws()
        {
            var releaseManager = MockHelper.CreateReleaseManager();
            AssertHelper.ShouldThrows<ArgumentNullException>(() =>
            {
                releaseManager.GetProducts(null);
            });
        }

        [TestMethod]
        public void GetProducts_ArgsEmpty_Should_OK()
        {
            var releaseManager = MockHelper.CreateReleaseManager();
            var result = releaseManager.GetProducts(new GetProductsArgs());
            result.LogJson();
        }
        
        [TestMethod]
        public void GetConfigItems_ArgsNull_Should_Throws()
        {
            var releaseManager = MockHelper.CreateReleaseManager();
            AssertHelper.ShouldThrows<ArgumentNullException>(() =>
            {
                releaseManager.GetConfigItems(null);
            });
        }

        [TestMethod]
        public void GetConfigItems_ArgsEmpty_Should_OK()
        {
            var releaseManager = MockHelper.CreateReleaseManager();
            var configItems = releaseManager.GetConfigItems(new GetConfigItemsArgs());
            configItems.LogJson();
        }
    }
}