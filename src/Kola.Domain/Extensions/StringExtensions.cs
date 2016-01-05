namespace Kola.Domain.Extensions
{
    using System;
    using System.Configuration;

    public static class StringExtensions
    {
        public static string StrongTrim(this string str)
        {
            return str.Trim('\n', '\r', '\t', ' ');
        }

        public static Uri ToStaticHostUri(this string path, string cacheBuster)
        {
            var queryString = cacheBuster.StrongTrim();

            if (!string.IsNullOrEmpty(queryString))
            {
                var joiner = path.Contains("?") ? "&" : "?";

                path = $"{path}{joiner}{queryString}";
            }

            if (path.StartsWith("http"))
            {
                return new Uri(path);
            }

            var hostUri = new Uri(ConfigurationManager.AppSettings["StaticContentRoot"]);

            if (path.StartsWith("/"))
            {
                path = path.Substring(1);
            }

            return new Uri(hostUri, path);
        }
    }
}