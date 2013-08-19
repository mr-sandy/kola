using System.Linq;
using System.Collections.Generic;

namespace Kola.Nancy.Extensions
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> TakeAllButLast<T>(this IEnumerable<T> list)
        {
            return list.Take(list.Count() - 1);
        }
    }
}