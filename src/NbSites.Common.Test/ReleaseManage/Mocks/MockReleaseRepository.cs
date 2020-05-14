using System;
using System.Collections.Generic;
using System.Linq;
using NbSites.Common.ReleaseManage.ConfigItems;
using NbSites.Common.ReleaseManage.Manifests;
using NbSites.Common.ReleaseManage.Products;

namespace NbSites.Common.ReleaseManage.Mocks
{
    public class MockReleaseRepository : IReleaseRepository
    {
        public MockReleaseRepository()
        {
            Products = new List<Product>();
            ConfigItems = new List<ConfigItem>();
            ReleaseManifests = new List<ReleaseManifest>();
            ConfigItemCommits = new List<ConfigItemCommit>();
            SeedProducts(this);
            SeedConfigItems(this);
            SeedManifests(this);
            SeedConfigItemCommits(this);
        }
        
        public IList<Product> Products { get; set; }
        public IList<ReleaseManifest> ReleaseManifests { get; set; }
        public IList<ConfigItem> ConfigItems { get; set; }
        public IList<ConfigItemCommit> ConfigItemCommits { get; set; }


        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public Product GetProduct(string productId)
        {
            var theOne = GetProducts().SingleOrDefault(x => x.Id == productId);
            return theOne;
        }

        public IEnumerable<ConfigItem> GetConfigItems()
        {
            return ConfigItems;
        }

        public ConfigItem GetConfigItem(string configItemId)
        {
            var theOne = GetConfigItems().SingleOrDefault(x => x.Id == configItemId);
            return theOne;
        }

        public IEnumerable<ReleaseManifest> GetReleaseManifests()
        {
            return ReleaseManifests;
        }

        public IEnumerable<ConfigItemCommit> GetConfigItemCommits()
        {
            return ConfigItemCommits;
        }

        private void SeedProducts(MockReleaseRepository repository)
        {
            var product = new Product();
            product.Id = "product_a";
            product.Name = "产品A";
            product.Desc = "产品A...";
            repository.Products.Add(product);
        }

        private void SeedConfigItems(MockReleaseRepository repository)
        {
            var product_a_specification = new ConfigItem();
            product_a_specification.Id = "product_a_specification";
            product_a_specification.Name = "《产品A需求说明书V1.0.0》";
            product_a_specification.Desc = "...";
            repository.ConfigItems.Add(product_a_specification);

            var product_a_server = new ConfigItem();
            product_a_server.Id = "product_a_server";
            product_a_server.Name = "产品A服务器";
            product_a_server.Desc = "...";
            repository.ConfigItems.Add(product_a_server);

            var log_server = new ConfigItem();
            log_server.Id = "log_server";
            log_server.Name = "日志服务器";
            log_server.Desc = "...";
            repository.ConfigItems.Add(log_server);
        }
        
        private void SeedManifests(MockReleaseRepository repository)
        {
            var product_a = repository.GetProduct("product_a");
            var product_a_specification = repository.GetConfigItem("product_a_specification");
            var product_a_server = repository.GetConfigItem("product_a_server");
            var log_server = repository.GetConfigItem("log_server");

            //product_a_release_1_0_0: release 1.0 at 2000-01-01
            var product_a_release_1_0_0 = new ReleaseManifest();
            product_a_release_1_0_0.ProductId = product_a.Id;
            product_a_release_1_0_0.Version = "1.0.0";
            product_a_release_1_0_0.Desc = "...";
            product_a_release_1_0_0.CreateAt = new DateTime(2000, 1, 1);

            product_a_release_1_0_0.WithConfigItem(product_a_specification.Id, "1.0.0");
            product_a_release_1_0_0.WithConfigItem(product_a_server.Id, "1.0.0");
            product_a_release_1_0_0.WithConfigItem(log_server.Id, "1.0.0");
            repository.ReleaseManifests.Add(product_a_release_1_0_0);

            //product_a_release_1_0_1: product_a_server bugs hot fix at 2000-02-01
            var product_a_release_1_0_1 = new ReleaseManifest();
            product_a_release_1_0_1.ProductId = product_a.Id;
            product_a_release_1_0_1.Version = "1.0.1";
            product_a_release_1_0_1.Desc = "...";
            product_a_release_1_0_1.CreateAt = new DateTime(2000, 2, 1);

            product_a_release_1_0_1.WithConfigItem(product_a_specification.Id, "1.0.0");
            product_a_release_1_0_1.WithConfigItem(product_a_server.Id, "1.0.1");
            product_a_release_1_0_1.WithConfigItem(log_server.Id, "1.0.0");
            repository.ReleaseManifests.Add(product_a_release_1_0_1);

            //product_a_release_1_1_0: release 1.1 at 2000-04-01
            var product_a_release_1_1_0 = new ReleaseManifest();
            product_a_release_1_1_0.ProductId = product_a.Id;
            product_a_release_1_1_0.Version = "1.1.0";
            product_a_release_1_1_0.Desc = "...";
            product_a_release_1_1_0.CreateAt = new DateTime(2000, 4, 1);

            product_a_release_1_1_0.WithConfigItem(product_a_specification.Id, "1.1.0");
            product_a_release_1_1_0.WithConfigItem(product_a_server.Id, "1.1.0");
            product_a_release_1_1_0.WithConfigItem(log_server.Id, "1.0.2");
            repository.ReleaseManifests.Add(product_a_release_1_1_0);
        }
        
        private void SeedConfigItemCommits(MockReleaseRepository repository)
        {
            //var product_a_specification_1_0_0 = new ConfigItem();
            //product_a_specification_1_0_0.Id = "product_a_specification_1_0_0";
            //product_a_specification_1_0_0.Category = "product_a_specification";
            //product_a_specification_1_0_0.Name = "《产品A需求说明书V1.0.0》";
            //product_a_specification_1_0_0.CreateBy = "张三疯";
            //product_a_specification_1_0_0.Version = "1.0.0";
            //product_a_specification_1_0_0.Desc = "...";
            //product_a_specification_1_0_0.CreateDate = new DateTime(2000, 1, 1);
            //product_a_specification_1_0_0.FilePath = "var/foo/blah/product_a_specification_1_0_0.docx";
            //mockReleaseRepository.ConfigItems.Add(product_a_specification_1_0_0);

            //var product_a_server_1_0_0 = new ConfigItem();
            //product_a_server_1_0_0.Id = "product_a_server_1_0_0";
            //product_a_server_1_0_0.Category = "product_a_server";
            //product_a_server_1_0_0.Name = "产品A服务器V1.0.0";
            //product_a_server_1_0_0.CreateBy = "李莫愁";
            //product_a_server_1_0_0.Version = "1.0.0";
            //product_a_server_1_0_0.Desc = "...";
            //product_a_server_1_0_0.CreateDate = new DateTime(2000, 2, 1);
            //product_a_server_1_0_0.FilePath = "var/foo/blah/product_a_server_1_0_0.zip";
            //mockReleaseRepository.ConfigItems.Add(product_a_server_1_0_0);

            //var log_server_1_2_0 = new ConfigItem();
            //log_server_1_2_0.Id = "log_server_1_2_0";
            //log_server_1_2_0.Category = "log_server";
            //log_server_1_2_0.Name = "日志服务器V1.2.0";
            //log_server_1_2_0.CreateBy = "张无忌";
            //log_server_1_2_0.Version = new Version(1, 2, 0);
            //log_server_1_2_0.Desc = "...";
            //log_server_1_2_0.CreateDate = new DateTime(2000, 1, 4);
            //log_server_1_2_0.FilePath = "var/foo/blah/log_server_1_2_0.zip";
            //mockReleaseRepository.ConfigItems.Add(log_server_1_2_0);

            //var log_server_1_3_0 = new ConfigItem();
            //log_server_1_3_0.Id = "log_server_1_3_0";
            //log_server_1_3_0.Name = "日志服务器V1.3.0";
            //log_server_1_3_0.CreateBy = "张无忌";
            //log_server_1_3_0.Version = new Version(1, 3, 0);
            //log_server_1_3_0.Desc = "...";
            //log_server_1_3_0.CreateDate = new DateTime(2000, 1, 20);
            //log_server_1_3_0.FilePath = "var/foo/blah/log_server_1_3_0.zip";
            //mockReleaseRepository.ConfigItems.Add(log_server_1_3_0);

            //var product_a_specification_1_1_0 = new ConfigItem();
            //product_a_specification_1_1_0.Id = "product_a_specification_1_1_0";
            //product_a_specification_1_1_0.Name = "《产品A需求说明书V1.1.0》";
            //product_a_specification_1_1_0.CreateBy = "张三疯";
            //product_a_specification_1_1_0.Version = "1.1.0";
            //product_a_specification_1_1_0.Desc = "...";
            //product_a_specification_1_1_0.CreateDate = new DateTime(2000, 5, 1);
            //product_a_specification_1_1_0.FilePath = "var/foo/blah/product_a_specification_1_1_0.docx";
            //mockReleaseRepository.ConfigItems.Add(product_a_specification_1_1_0);

            //var product_a_server_1_1_0 = new ConfigItem();
            //product_a_server_1_1_0.Id = "product_a_server_1_1_0";
            //product_a_server_1_1_0.Name = "产品A服务器V1.1.0";
            //product_a_server_1_1_0.CreateBy = "李莫愁";
            //product_a_server_1_1_0.Version = "1.1.0";
            //product_a_server_1_1_0.Desc = "...";
            //product_a_server_1_1_0.CreateDate = new DateTime(2000, 5, 1);
            //product_a_server_1_1_0.FilePath = "var/foo/blah/product_a_server_1_1_0.zip";
            //mockReleaseRepository.ConfigItems.Add(product_a_server_1_1_0);



            //var product_a_specification_1_0_0 = new ConfigItem();
            //product_a_specification_1_0_0.Id = "product_a_specification_1_0_0";
            //product_a_specification_1_0_0.Category = "product_a_specification";
            //product_a_specification_1_0_0.Name = "《产品A需求说明书V1.0.0》";
            //product_a_specification_1_0_0.CreateBy = "张三疯";
            //product_a_specification_1_0_0.Version = "1.0.0";
            //product_a_specification_1_0_0.Desc = "...";
            //product_a_specification_1_0_0.CreateDate = new DateTime(2000, 1, 1);
            //product_a_specification_1_0_0.FilePath = "var/foo/blah/product_a_specification_1_0_0.docx";
            //repository.ConfigItems.Add(product_a_specification_1_0_0);

            //var product_a_server_1_0_0 = new ConfigItem();
            //product_a_server_1_0_0.Id = "product_a_server_1_0_0";
            //product_a_server_1_0_0.Category = "product_a_server";
            //product_a_server_1_0_0.Name = "产品A服务器V1.0.0";
            //product_a_server_1_0_0.CreateBy = "李莫愁";
            //product_a_server_1_0_0.Version = "1.0.0";
            //product_a_server_1_0_0.Desc = "...";
            //product_a_server_1_0_0.CreateDate = new DateTime(2000, 2, 1);
            //product_a_server_1_0_0.FilePath = "var/foo/blah/product_a_server_1_0_0.zip";
            //repository.ConfigItems.Add(product_a_server_1_0_0);

            //var log_server_1_2_0 = new ConfigItem();
            //log_server_1_2_0.Id = "log_server_1_2_0";
            //log_server_1_2_0.Category = "log_server";
            //log_server_1_2_0.Name = "日志服务器V1.2.0";
            //log_server_1_2_0.CreateBy = "张无忌";
            //log_server_1_2_0.Version = new Version(1, 2, 0);
            //log_server_1_2_0.Desc = "...";
            //log_server_1_2_0.CreateDate = new DateTime(2000, 1, 4);
            //log_server_1_2_0.FilePath = "var/foo/blah/log_server_1_2_0.zip";
            //repository.ConfigItems.Add(log_server_1_2_0);

            //var log_server_1_3_0 = new ConfigItem();
            //log_server_1_3_0.Id = "log_server_1_3_0";
            //log_server_1_3_0.Name = "日志服务器V1.3.0";
            //log_server_1_3_0.CreateBy = "张无忌";
            //log_server_1_3_0.Version = new Version(1, 3, 0);
            //log_server_1_3_0.Desc = "...";
            //log_server_1_3_0.CreateDate = new DateTime(2000, 1, 20);
            //log_server_1_3_0.FilePath = "var/foo/blah/log_server_1_3_0.zip";
            //repository.ConfigItems.Add(log_server_1_3_0);

            //var product_a_specification_1_1_0 = new ConfigItem();
            //product_a_specification_1_1_0.Id = "product_a_specification_1_1_0";
            //product_a_specification_1_1_0.Name = "《产品A需求说明书V1.1.0》";
            //product_a_specification_1_1_0.CreateBy = "张三疯";
            //product_a_specification_1_1_0.Version = "1.1.0";
            //product_a_specification_1_1_0.Desc = "...";
            //product_a_specification_1_1_0.CreateDate = new DateTime(2000, 5, 1);
            //product_a_specification_1_1_0.FilePath = "var/foo/blah/product_a_specification_1_1_0.docx";
            //repository.ConfigItems.Add(product_a_specification_1_1_0);

            //var product_a_server_1_1_0 = new ConfigItem();
            //product_a_server_1_1_0.Id = "product_a_server_1_1_0";
            //product_a_server_1_1_0.Name = "产品A服务器V1.1.0";
            //product_a_server_1_1_0.CreateBy = "李莫愁";
            //product_a_server_1_1_0.Version = "1.1.0";
            //product_a_server_1_1_0.Desc = "...";
            //product_a_server_1_1_0.CreateDate = new DateTime(2000, 5, 1);
            //product_a_server_1_1_0.FilePath = "var/foo/blah/product_a_server_1_1_0.zip";
            //repository.ConfigItems.Add(product_a_server_1_1_0);
        }
    }
}