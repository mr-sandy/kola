namespace Kola.Domain.Extensions
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
            return list == null
                ? null
                : list.Concat(new[] { item });
        }

        // Compares two lists.  If the one list is a leading subset of the other, returns the smaller list.
        // Otherwise returns the input.
        // e.g.  
        //      0,1,2   & 0,1,2,3,4,5 returns 0,1,2
        //      0,1,2,4 & 0,1,2,3,4,5 returns 0,1,2,4 & 0,1,2,3,4,5
        public static IEnumerable<IEnumerable<T>> Consolidate<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {
            // Find the shorter list
            var array1 = list1 as T[] ?? list1.ToArray();
            var array2 = list2 as T[] ?? list2.ToArray();

            var shorter = (array1.Count() > array2.Count()) ? array2 : array1;

            for (var i = 0; i < shorter.Count(); i++)
            {
                if (!array1.ElementAt(i).Equals(array2.ElementAt(i)))
                {
                    return new[] { array1, array2 };
                }
            }

            return new[] { shorter };
        }

        public static IEnumerable<int> Compensate(this IEnumerable<int> targetPath, IEnumerable<int> sourcePath)
        {
            var target = targetPath as int[] ?? targetPath.ToArray();
            var source = sourcePath as int[] ?? sourcePath.ToArray();

            var matching = true;

            // 'subtract' the source path from the target path to compensate for its removal
            for (var i = 0; i < target.Length; i++)
            {
                var endOfSource = i == source.Length - 1;
                var endOfTarget = i == target.Length - 1;

                if (matching && endOfSource && !endOfTarget && source[i] < target[i])
                {
                    yield return target[i] - 1;
                    matching = false;
                }
                else
                {
                    yield return target[i];
                    matching = i < source.Length && source[i] == target[i];
                }
            }
        }


        public static IEnumerable<int> IncrementLast(this IEnumerable<int> list)
        {
            var array = list as int[] ?? list.ToArray();

            return array.TakeAllButLast().Append(array.Last() + 1);
        }
    }
}