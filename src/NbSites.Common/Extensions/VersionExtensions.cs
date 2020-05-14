using System;
// ReSharper disable once CheckNamespace
namespace NbSites.Common
{
    public static class VersionExtensions
    {
        public static Version TryConvertToVersion(this string version, Version failValue = null)
        {
            var tryParse = Version.TryParse(version, out var theVersion);
            return !tryParse ? failValue : theVersion;
        }

        public static bool TryCompareAsVersion(this string version, string anotherVersion)
        {
            var versionA = version.TryConvertToVersion(null);
            if (versionA == null)
            {
                return false;
            }
            var versionB = anotherVersion.TryConvertToVersion(null);
            return versionA == versionB;
        }
    }
}
