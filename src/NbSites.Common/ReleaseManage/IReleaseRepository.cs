using System.Collections.Generic;
using NbSites.Common.ReleaseManage.ConfigItems;
using NbSites.Common.ReleaseManage.Manifests;
using NbSites.Common.ReleaseManage.Products;

namespace NbSites.Common.ReleaseManage
{
    public interface IReleaseRepository
    {

        IEnumerable<Product> GetProducts();
        Product GetProduct(string productId);

        IEnumerable<ConfigItem> GetConfigItems();
        ConfigItem GetConfigItem(string configItemId);

        IEnumerable<ReleaseManifest> GetReleaseManifests();
        IEnumerable<ConfigItemCommit> GetConfigItemCommits();
    }
}
