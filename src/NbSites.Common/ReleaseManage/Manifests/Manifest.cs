using System;
using System.Collections.Generic;
using System.Linq;

namespace NbSites.Common.ReleaseManage.Manifests
{
    /// <summary>
    /// 发布清单
    /// </summary>
    public class ReleaseManifest
    {
        public ReleaseManifest()
        {
            Items = new List<ReleaseManifestItem>();
        }

        /// <summary>
        /// 产品Id
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 产品的发布版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// 清单项列表
        /// </summary>
        public IList<ReleaseManifestItem> Items { get; set; }
        
        public ReleaseManifest WithConfigItem(string configItemId, string configItemVersion)
        {
            var theOne = Items.SingleOrDefault(x => x.ConfigItemId.MyEquals(configItemId) && x.ConfigItemVersion.TryCompareAsVersion(configItemVersion));
            if (theOne == null)
            {
                theOne = new ReleaseManifestItem();
                theOne.ConfigItemId = configItemId;
                theOne.ConfigItemVersion = configItemVersion;
                Items.Add(theOne);
            }

            return this;
        }
    }

    /// <summary>
    /// 发布清单项
    /// </summary>
    public class ReleaseManifestItem
    {
        /// <summary>
        /// 配置项Id
        /// </summary>
        public string ConfigItemId { get; set; }
        /// <summary>
        /// 配置项版本
        /// </summary>
        public string ConfigItemVersion { get; set; }
    }
}
