using System;
using System.Collections.Generic;
using System.Linq;
using NbSites.Common.ReleaseManage.ConfigItems;
using NbSites.Common.ReleaseManage.Manifests;
using NbSites.Common.ReleaseManage.Products;

namespace NbSites.Common.ReleaseManage
{
    public interface IReleaseManager
    {
        IList<Product> GetProducts(GetProductsArgs args);
        IList<ConfigItem> GetConfigItems(GetConfigItemsArgs args);
        ReleaseManifest GetReleaseManifest(GetReleaseManifestArgs args);
        //MessageResult AddConfigItem(ConfigItem configItem);
        //MessageResult RemoveConfigItem(ConfigItem configItem);
        //ConfigItem GetConfigItem();
    }

    public class GetProductsArgs
    {
        //todo
    }

    public class GetConfigItemsArgs
    {
        //todo
    }

    public class GetReleaseManifestArgs
    {
        public string ProductId { get; set; }
        public string Version { get; set; }
    }

    public class ReleaseManager : IReleaseManager
    {
        private readonly IReleaseRepository _repository;

        public ReleaseManager(IReleaseRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IList<Product> GetProducts(GetProductsArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            var list = _repository.GetProducts().OrderBy(x => x.Name).ToList();
            return list;
        }

        public IList<ConfigItem> GetConfigItems(GetConfigItemsArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            var list = _repository.GetConfigItems().OrderBy(x => x.Name).ToList();
            return list;
        }

        public ReleaseManifest GetReleaseManifest(GetReleaseManifestArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            if (string.IsNullOrWhiteSpace(args.ProductId))
            {
                return null;
            }

            var tryParse = Version.TryParse(args.Version, out var version);
            if (!tryParse)
            {
                return null;
            }
            
            var theOne = _repository.GetReleaseManifests().SingleOrDefault(x => x.ProductId == args.ProductId && x.Version == version);
            return theOne;
        }
    }
}