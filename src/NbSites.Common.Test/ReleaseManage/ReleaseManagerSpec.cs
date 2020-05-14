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
            var result = releaseManager.GetConfigItems(new GetConfigItemsArgs());
            result.LogJson();
        }


        [TestMethod]
        public void GetReleaseManifest_ArgsNull_Should_Throws()
        {
            var releaseManager = MockHelper.CreateReleaseManager();
            AssertHelper.ShouldThrows<ArgumentNullException>(() =>
            {
                releaseManager.GetReleaseManifest(null);
            });
        }

        [TestMethod]
        public void GetReleaseManifest_ArgsEmpty_Should_ReturnNull()
        {
            var releaseManager = MockHelper.CreateReleaseManager();
            var result = releaseManager.GetReleaseManifest(new GetReleaseManifestArgs());
            result.LogJson();
            result.ShouldNull();
        }

        [TestMethod]
        public void GetReleaseManifest_ArgsBadProductId_Should_ReturnNull()
        {
            var releaseManager = MockHelper.CreateReleaseManager();
            var result = releaseManager.GetReleaseManifest(new GetReleaseManifestArgs() { Version = "1.0", ProductId = "" });
            result.LogJson();
            result.ShouldNull();
        }

        [TestMethod]
        public void GetReleaseManifest_ArgsBadVersion_Should_ReturnNull()
        {
            var releaseManager = MockHelper.CreateReleaseManager();
            var result = releaseManager.GetReleaseManifest(new GetReleaseManifestArgs() { Version = "1.0.abc", ProductId = "product_a" });
            result.LogJson();
            result.ShouldNull();
        }

        [TestMethod]
        public void GetReleaseManifest_Exist_Should_Return()
        {
            var releaseManager = MockHelper.CreateReleaseManager();
            var result = releaseManager.GetReleaseManifest(new GetReleaseManifestArgs() { Version = "1.0.0", ProductId = "product_a" });
            result.LogJson(true);
            result.ShouldNotNull();
        }



        [TestMethod]
        public void Export_Should_Ok()
        {
            var releaseManager = MockHelper.CreateReleaseManager();
            var result = releaseManager.Export();
            result.LogJson(true);
            result.ShouldNotNull();
        }
    }
}