using System;
// ReSharper disable once CheckNamespace
namespace NbSites.Common
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool MyEquals(this string value, string value2, bool trimSpaceBeforeCompare = true)
        {
            if (value == null && value2 == null)
            {
                return true;
            }

            if (value == null)
            {
                return false;
            }

            if (value2 == null)
            {
                return false;
            }

            var ordinalIgnoreCase = StringComparison.OrdinalIgnoreCase;
            return trimSpaceBeforeCompare
                ? value.Trim().Equals(value2.Trim(), ordinalIgnoreCase) 
                : value.Equals(value2, ordinalIgnoreCase);
        }
    }
}