namespace Kola.Nancy.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> TakeAllButLast<T>(this IEnumerable<T> list)
        {
            return list.Take(list.Count() - 1);
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> list, T item)
        {
            return list.Concat(new[] { item });
        }
    }
}