
namespace Kola.Extensions
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

        public static string ToFileSystemPath(this IEnumerable<string> elements)
        {
            return string.Join(@"\", elements);
        }

        public static string ToHttpPath(this IEnumerable<string> elements)
        {
            return string.Format("/{0}", string.Join(@"/", elements));
        }

        public static IEnumerable<string> ParseTemplatePath(this string path)
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
    }
}