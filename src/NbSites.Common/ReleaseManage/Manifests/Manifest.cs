using System;
using System.Collections.Generic;

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

        public string ProductId { get; set; }
        public Version Version { get; set; }
        public string Desc { get; set; }
        public DateTime CreateAt { get; set; }

        public IList<ReleaseManifestItem> Items { get; set; }
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
        public Version ConfigItemVersion { get; set; }
    }
}
