namespace Kola.Service.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class StringExtensions
    {
        public static string Urlify(this string raw)
        {
            return string.IsNullOrEmpty(raw)
                ? string.Empty
                : raw.ToLower().Replace(" ", "-");
        }

        public static string ToHttpPath(this IEnumerable<string> elements)
        {
            return $"/{string.Join(@"/", elements)}";
        }

        public static IEnumerable<string> ParsePath(this string path)
        {
            return path.Split('\\', '/').Where(s => !string.IsNullOrWhiteSpace(s));
        }

        public static IEnumerable<int> ParseComponentPath(this string path)
        {
            return path.Split('/').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => int.Parse(s));
        }

        public static string ToComponentPathString(this IEnumerable<int> componentPath)
        {
            return string.Join("/", componentPath);
        }

        public static string ToComponentName(this string componentTypeUri)
        {
            var lastSlash = componentTypeUri.LastIndexOf("/", StringComparison.Ordinal);

            return lastSlash < 0 
                ? componentTypeUri 
                : componentTypeUri.Substring(lastSlash + 1);
        }

        public static string StrongTrim(this string str)
        {
            return str.Trim('\n', '\r', '\t', ' ');
        }
    }
}