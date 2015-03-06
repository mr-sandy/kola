namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class StringExtensions
    {
        public static string ToFileSystemPath(this IEnumerable<string> elements)
        {
            return string.Join(@"\", elements);
        }

        public static IEnumerable<int> ParseComponentPath(this string path)
        {
            return path.Split('/').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse);
        }

        public static string ToComponentPathString(this IEnumerable<int> componentPath)
        {
            return string.Join("/", componentPath);
        }
    }
}