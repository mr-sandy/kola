namespace Kola.Nancy.Extensions
{
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

        public static IEnumerable<string> ParsePath(this string path)
        {
            return path.Split('\\', '/').Where(s => !string.IsNullOrWhiteSpace(s));
        }

        public static IEnumerable<int> ParseComponentPath(this string path)
        {
            return path.Split('/').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => int.Parse(s));
        }
    }
}