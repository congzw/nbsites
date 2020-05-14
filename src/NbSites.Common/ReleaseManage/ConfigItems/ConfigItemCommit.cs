using System;

namespace NbSites.Common.ReleaseManage.ConfigItems
{
    public class ConfigItemCommit
    {
        /// <summary>
        /// 配置项Id
        /// </summary>
        public string ConfigItemId { get; set; }
        /// <summary>
        /// 配置项版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt { get; set; }
        /// <summary>
        /// 用于获取配置项的位置信息
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Desc { get; set; }
    }
}