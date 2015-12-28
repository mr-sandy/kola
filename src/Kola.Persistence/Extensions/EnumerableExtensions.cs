namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class EnumerableExtensions
    {
     
        public static IEnumerable<T> Append<T>(this IEnumerable<T> list, T item)
        {
            return list?.Concat(new[] { item }) ?? new[] { item };
        }
    }
}