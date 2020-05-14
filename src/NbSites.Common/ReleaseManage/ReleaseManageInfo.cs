using System.Collections.Generic;
using System.IO;
using System.Text;
using NbSites.Common.ReleaseManage.ConfigItems;
using NbSites.Common.ReleaseManage.Manifests;
using NbSites.Common.ReleaseManage.Products;

namespace NbSites.Common.ReleaseManage
{
    public class ReleaseManageInfo
    {
        public ReleaseManageInfo()
        {
            Products = new List<Product>();
            ConfigItems = new List<ConfigItem>();
            ReleaseManifests = new List<ReleaseManifest>();
            ConfigItemCommits = new List<ConfigItemCommit>();
        }

        public IList<Product> Products { get; set; }
        public IList<ConfigItem> ConfigItems { get; set; }
        public IList<ConfigItemCommit> ConfigItemCommits { get; set; }
        public IList<ReleaseManifest> ReleaseManifests { get; set; }

        public void Load(string filePath)
        {
            var myJsonHelper = MyJsonHelper.Resolve();
            var json = File.ReadAllText(filePath);
            var repositoryInfo = myJsonHelper.DeserializeObject<ReleaseManageInfo>(json, null);
            if (repositoryInfo != null)
            {
                this.Products = repositoryInfo.Products;
                this.ConfigItems = repositoryInfo.ConfigItems;
                this.ReleaseManifests = repositoryInfo.ReleaseManifests;
                this.ConfigItemCommits = repositoryInfo.ConfigItemCommits;
            }
        }

        public void Save(string filePath)
        {
            var myJsonHelper = MyJsonHelper.Resolve();
            var json = myJsonHelper.SerializeObject(this, true);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }
    }
}