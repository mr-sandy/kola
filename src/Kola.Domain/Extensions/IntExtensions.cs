namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class IntExtensions
    {
        public static string ToHttpPath(this IEnumerable<int> elements)
        {
            return elements == null 
                ? null 
                : string.Format("/{0}", string.Join(@"/", elements));
        }

        public static bool IsEquivalentTo(this IEnumerable<int> first, IEnumerable<int> second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            if (first.Count() != second.Count())
            {
                return false;
            }

            for (var i = 0; i < first.Count(); i++)
            {
                if (first.ElementAt(i) != second.ElementAt(i))
                {
                    return false;
                }
            }

            return true;
        }
    }
}