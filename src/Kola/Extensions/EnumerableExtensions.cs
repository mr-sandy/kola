namespace Kola.Extensions
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

        public static IEnumerable<T> GetOverlap<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {
            var length = (list1.Count() > list2.Count()) ? list2.Count() : list1.Count();

            for (var i = 0; i < length; i++)
            {
                if (list1.ElementAt(i).Equals(list2.ElementAt(i)))
                {
                    yield return list1.ElementAt(i);
                }
            }
        }
    }
}