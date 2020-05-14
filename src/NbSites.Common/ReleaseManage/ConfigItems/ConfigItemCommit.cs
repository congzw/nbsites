using System;

namespace NbSites.Common.ReleaseManage.ConfigItems
{
    public class ConfigItemCommit
    {
        public string ConfigItemId { get; set; }
        public string Version { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string FilePath { get; set; }
        public string Desc { get; set; }
    }
}