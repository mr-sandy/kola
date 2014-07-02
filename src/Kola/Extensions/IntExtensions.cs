namespace Kola.Extensions
{
    using System.Collections.Generic;

    internal static class IntExtensions
    {
        public static string ToHttpPath(this IEnumerable<int> elements)
        {
            return elements == null 
                ? null 
                : string.Format("/{0}", string.Join(@"/", elements));
        }
    }
}