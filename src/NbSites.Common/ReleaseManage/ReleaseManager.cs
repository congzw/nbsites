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
        IList<ConfigItemCommit> GetConfigItemCommits(GetConfigItemCommitsArgs args);
        IList<ReleaseManifest> GetReleaseManifests(GetReleaseManifestsArgs args);
        ReleaseManifest GetReleaseManifest(GetReleaseManifestArgs args);
        ReleaseManageInfo Export();
        
        //MessageResult AddConfigItem(ConfigItem configItem);
        //MessageResult RemoveConfigItem(ConfigItem configItem);
        //ConfigItem GetConfigItem();
    }

    public class GetConfigItemCommitsArgs
    {
    }

    public class GetReleaseManifestsArgs
    {
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

        public IList<ConfigItemCommit> GetConfigItemCommits(GetConfigItemCommitsArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var items = _repository.GetConfigItemCommits().OrderBy(x => x.CreateAt).ToList();
            return items;
        }

        public IList<ReleaseManifest> GetReleaseManifests(GetReleaseManifestsArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var items = _repository.GetReleaseManifests().OrderBy(x => x.ProductId).ThenBy(x => x.Version).ToList();
            return items;
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

        public ReleaseManageInfo Export()
        {
            var info = new ReleaseManageInfo();
            info.Products = GetProducts(new GetProductsArgs());
            info.ConfigItems = GetConfigItems(new GetConfigItemsArgs());
            info.ConfigItemCommits = GetConfigItemCommits(new GetConfigItemCommitsArgs());
            info.ReleaseManifests = GetReleaseManifests(new GetReleaseManifestsArgs());
            return info;
        }
    }
}