namespace Kola.Persistence.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> list, T item)
        {
            return list?.Concat(new[] { item }) ?? new[] { item };
        }

        public static T Random<T>(this IEnumerable<T> list)
        {
            var arr = list as T[] ?? list.ToArray();
            var random = new Random();

            return arr.ElementAt(random.Next(arr.Length));
        }
    }
}