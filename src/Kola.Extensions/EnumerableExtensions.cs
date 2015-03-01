namespace Kola.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> TakeAllButLast<T>(this IEnumerable<T> list)
        {
            return list.Take(list.Count() - 1);
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> list, T item)
        {
            return list == null
                ? null
                : list.Concat(new[] { item });
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> list, T item)
        {
            return list == null
                ? new[] { item }
                : list.Concat(new[] { item });
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

        // Compares two lists.  If the one list is a leading subset of the other, returns the smaller list.
        // Otherwise returns the input.
        // e.g.  
        //      0,1,2   & 0,1,2,3,4,5 returns 0,1,2
        //      0,1,2,4 & 0,1,2,3,4,5 returns 0,1,2,4 & 0,1,2,3,4,5
        public static IEnumerable<IEnumerable<T>> Consolidate<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {
            // Find the shorter list
            var shorter = (list1.Count() > list2.Count()) ? list2 : list1;

            for (var i = 0; i < shorter.Count(); i++)
            {
                if (!list1.ElementAt(i).Equals(list2.ElementAt(i)))
                {
                    return new[] { list1, list2 };
                }
            }

            return new[] { shorter };
        }
    }
}