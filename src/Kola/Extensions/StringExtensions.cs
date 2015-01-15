namespace Kola.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    internal static class StringExtensions
    {
        public static string Urlify(this string raw)
        {
            return string.IsNullOrEmpty(raw)
                ? string.Empty
                : raw.ToLower().Replace(" ", "-");
        }

        public static string ToFileSystemPath(this IEnumerable<string> elements)
        {
            return string.Join(@"\", elements);
        }

        public static string ToHttpPath(this IEnumerable<string> elements)
        {
            return string.Format("/{0}", string.Join(@"/", elements));
        }

        public static IEnumerable<string> ParsePath(this string path)
        {
            return path.Split('\\', '/');
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
            var lastSlash = componentTypeUri.LastIndexOf("/");

            return lastSlash < 0 
                ? componentTypeUri 
                : componentTypeUri.Substring(lastSlash + 1);
        }

        public static string StrongTrim(this string str)
        {
            return str.Trim(new[] { '\n', '\r', '\t', ' ' });
        }

        public static Uri ToStaticHostUri(this string path, string cacheBuster)
        {
            var queryString = cacheBuster.StrongTrim();

            if (!string.IsNullOrEmpty(queryString))
            {
                var joiner = path.Contains("?") ? "&" : "?";

                path = string.Format("{0}{1}{2}", path, joiner, queryString);
            }

            var hostUri = new Uri(ConfigurationManager.AppSettings["StaticContentRoot"]);
            
            return new Uri(hostUri, path);
        }
    }
}